#version 460

layout (location = 0) in vec2 inUV;

struct PointLight
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
    float radius;
    float far_plane;
    int enabled;
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
layout (binding = 11) uniform sampler2D uEmissiveTexture;

layout(std140, binding = 2) uniform UBOLights
{
    PointLight point_light_list[1000];
} uniforms;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

float ToLinear(float value)
{
    return pow(value, 2.20f);
}

void main() 
{
    vec4 finalColor = vec4(0, 0, 0, 0);

    // Read the diffuse color
	vec4 DiffuseColor = texture(uDiffuseTexture, inUV);
    finalColor.a = DiffuseColor.a;

    // Read normal
    vec3 normal = vec3(texture(uNormalTexture, inUV));

    vec3 vertPos = vec3(texture(uPositionTexture, inUV));

    const float Shininess = mix( 1, 100, 1 - texture( uRoughnessTexture, inUV).r );

    vec3 glossiveness = texture(uGlossinessTexture, inUV).rgb;

    // Viewer to fragment
	vec3 EyeDirection = vertPos - pushConsts.world_eye_pos.xyz;
	EyeDirection = normalize(EyeDirection);

    for (int i = pushConsts.user_param; i < pushConsts.user_param + pushConsts.user_param2; ++i)
    {        
    	if (uniforms.point_light_list[i].enabled == 0) continue;

        // Point light color from gamma to linear
        vec3 light_color = pow(uniforms.point_light_list[i].color.rgb, vec3(2.20f));

        // Vector to light
		vec3 LightDirection = uniforms.point_light_list[i].position - vertPos;
		// Distance from light to fragment position
		float dist = length(LightDirection);
        LightDirection = normalize(LightDirection);

	    // Compute the diffuse intensity
	    float DiffuseI  = max( 0, dot(normal, LightDirection ));
        vec3 ComputedDiffuse = DiffuseI.rrr * DiffuseColor.rgb;

        // Determine the power for the specular based on how rough something is
        float SpecularI2  = pow( max( 0, dot(normal, normalize( LightDirection - EyeDirection ))), Shininess );
        //vec3 reflectDir = reflect(-LightDirection, normal);  
        //float SpecularI1  = pow( max( 0, dot(-EyeDirection, reflectDir)), Shininess );
        vec3 ComputedSpecular = SpecularI2.rrr * glossiveness;

        // Attenuation
        float denom_atten = (dist / uniforms.point_light_list[i].radius) + 1.0;
        float Attenuation = 1.0 / (denom_atten * denom_atten);

	    // Add the contribution of this light
        finalColor.rgb += uniforms.point_light_list[i].intensity * light_color * (ComputedDiffuse + ComputedSpecular) * 
        Attenuation;
    }

    outFragColor = finalColor;
}
