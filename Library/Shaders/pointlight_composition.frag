#version 460

layout (location = 0) in vec2 inUV;

struct PointLight
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
    float radius;
    float far_plane;
};

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 ambient_color;
    vec2 viewport_size;
    int user_param;
    int user_param2;
    int user_param3;
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;


layout (location = 0) out vec4 outFragColor;

layout (binding = 5) uniform sampler2D uPositionTexture;
layout (binding = 6) uniform sampler2D uDiffuseTexture;
layout (binding = 7) uniform sampler2D uNormalTexture;
layout (binding = 8) uniform sampler2D uAmbientTexture;
layout (binding = 9) uniform sampler2D uRoughnessTexture;
layout (binding = 10) uniform sampler2D uGlossinessTexture;
layout (binding = 11) uniform samplerCubeArray uPointLightDepthMap;
layout (binding = 12) uniform sampler2DArray uDirectionalLightDepthMap;

layout(std140, binding = 2) uniform UBOLights
{
    PointLight point_light_list[1000];
} uniforms;


vec3 sampleOffsetDirections[20] = vec3[]
(
   vec3( 1,  1,  1), vec3( 1, -1,  1), vec3(-1, -1,  1), vec3(-1,  1,  1), 
   vec3( 1,  1, -1), vec3( 1, -1, -1), vec3(-1, -1, -1), vec3(-1,  1, -1),
   vec3( 1,  1,  0), vec3( 1, -1,  0), vec3(-1, -1,  0), vec3(-1,  1,  0),
   vec3( 1,  0,  1), vec3(-1,  0,  1), vec3( 1,  0, -1), vec3(-1,  0, -1),
   vec3( 0,  1,  1), vec3( 0, -1,  1), vec3( 0, -1, -1), vec3( 0,  1, -1)
);

float ShadowCalculation(vec3 fragPos, int ls_index)
{
    float far_plane = uniforms.point_light_list[ls_index].far_plane;
    // get vector between fragment position and light position
    vec3 fragToLight = fragPos - uniforms.point_light_list[ls_index].position;
    // now get current linear depth as the length between the fragment and light position
    float currentDepth = length(fragToLight);
    // now test for shadows
    float shadow = 0.0;
    float bias   = 0.15;
    int samples  = 20;
    float viewDistance = length(vec3(pushConsts.world_eye_pos) - fragPos);
    float diskRadius = (1.0 + (viewDistance / far_plane)) / 25.0;
    for(int i = 0; i < samples; ++i)
    {
        float closestDepth = texture(uPointLightDepthMap, vec4(fragToLight + sampleOffsetDirections[i] * diskRadius, ls_index - pushConsts.user_param)).r;
        closestDepth *= far_plane;   // undo mapping [0;1]
        if(currentDepth - bias <= closestDepth)
            shadow += 1.0;
    }
    shadow /= float(samples);
    return shadow;
}

void main() 
{
    vec4 finalColor = vec4(0, 0, 0, 0);

    // Read the diffuse color
	vec4 DiffuseColor = texture(uDiffuseTexture, inUV);
    
    // Read normal
    vec3 normal = vec3(texture(uNormalTexture, inUV));

    vec3 vertPos = vec3(texture(uPositionTexture, inUV));

    for (int i = pushConsts.user_param; i < pushConsts.user_param + pushConsts.user_param2; ++i)
    {        
        // Vector to light
		vec3 LightDirection = uniforms.point_light_list[i].position - vertPos;
		// Distance from light to fragment position
		float dist = length(LightDirection);
        LightDirection = normalize(LightDirection);

	    // Compute the diffuse intensity
	    float DiffuseI  = max( 0, dot(normal, LightDirection ));
        vec3 ComputedDiffuse = uniforms.point_light_list[i].intensity * uniforms.point_light_list[i].color.rgb * DiffuseI.rrr * DiffuseColor.rgb;

        // Viewer to fragment
		vec3 EyeDirection = pushConsts.world_eye_pos.xyz - vertPos;
		EyeDirection = normalize(EyeDirection);

        // Determine the power for the specular based on how rough something is
        const float Shininess = mix( 1, 100, 1 - texture( uRoughnessTexture, inUV).r );
        float SpecularI2  = pow( max( 0, dot(normal, normalize( LightDirection - EyeDirection ))), Shininess );
        vec3 ComputedSpecular = uniforms.point_light_list[i].intensity * uniforms.point_light_list[i].color.rgb * SpecularI2.rrr * texture(uGlossinessTexture, inUV).rgb;

        // Attenuation
        float denom_atten = (dist / uniforms.point_light_list[i].radius) + 1.0;
        float Attenuation = 1.0 / (denom_atten * denom_atten);

	    // Add the contribution of this light
        finalColor.rgb += (ComputedDiffuse + ComputedSpecular) * ShadowCalculation(vertPos, i) * Attenuation;
    }

    outFragColor = finalColor;
}
