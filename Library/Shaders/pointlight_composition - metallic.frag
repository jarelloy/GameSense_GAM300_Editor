#version 460
#extension GL_GOOGLE_include_directive : enable
#include "PBR.glsl"
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
layout (binding = 11) uniform sampler2D uEmissiveTexture;
layout (binding = 12) uniform samplerCubeArray uPointLightDepthMap;
layout (binding = 13) uniform sampler2DArray uDirectionalLightDepthMap;

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
	vec3 albedo = texture(uDiffuseTexture, inUV).rgb;
    
    // Read normal
    vec3 normal = vec3(texture(uNormalTexture, inUV));

    // Read position
    vec3 vertPos = vec3(texture(uPositionTexture, inUV));

    // Read metallic
    float Metalness = texture(uGlossinessTexture, inUV).r;

    // Read roughness
    float roughness = 1.f - texture(uRoughnessTexture, inUV).r;

    // Viewer to fragment
	vec3 EyeDirection = pushConsts.world_eye_pos.xyz - vertPos;
	EyeDirection = normalize(EyeDirection);

    vec3 F0 = vec3(0.04); 
    F0 = mix(F0, albedo.rgb, Metalness);

    for (int i = pushConsts.user_param; i < pushConsts.user_param + pushConsts.user_param2; ++i)
    {        
        // Point light color from gamma to linear
        vec3 light_color = pow(uniforms.point_light_list[i].color.rgb, vec3(2.20f));

        // calculate per-light radiance
		vec3 LightDirection = uniforms.point_light_list[i].position - vertPos;
        vec3 H = normalize(EyeDirection + LightDirection);
		float dist = length(LightDirection);
        float denom_atten = (dist / uniforms.point_light_list[i].radius) + 1.0;
        float Attenuation = 1.0 / (denom_atten * denom_atten);
        vec3 radiance = uniforms.point_light_list[i].intensity * light_color * Attenuation;

        // Cook-Torrance BRDF
        float NDF = DistributionGGX(normal, H, roughness);   
        float G   = GeometrySmith(normal, EyeDirection, LightDirection, roughness);      
        vec3 F    = fresnelSchlick(max(dot(H, EyeDirection), 0.0), F0);

        vec3 numerator    = NDF * G * F; 
        float denominator = 4.0 * max(dot(normal, EyeDirection), 0.0) * max(dot(normal, LightDirection), 0.0) + 0.0001; // + 0.0001 to prevent divide by zero
        vec3 specular = numerator / denominator;

        // kS is equal to Fresnel
        vec3 kS = F;
        // for energy conservation, the diffuse and specular light can't
        // be above 1.0 (unless the surface emits light); to preserve this
        // relationship the diffuse component (kD) should equal 1.0 - kS.
        vec3 kD = vec3(1.0) - kS;
        // multiply kD by the inverse metalness such that only non-metals 
        // have diffuse lighting, or a linear blend if partly metal (pure metals
        // have no diffuse light).
        kD *= 1.0 - Metalness;	  

        // scale light by NdotL
        float NdotL = max(dot(normal, LightDirection), 0.0);

         // add to outgoing radiance
        finalColor.rgb += (kD * albedo / PI + specular) * radiance * NdotL * ShadowCalculation(vertPos, i);  
        // note that we already multiplied the BRDF by the Fresnel (kS) so we won't multiply by kS again
    }

    outFragColor = finalColor;
}
