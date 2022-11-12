#version 460

layout (location = 0) in vec2 inUV;

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

void main() 
{
    vec4 finalColor = vec4(0, 0, 0, 0);

    // Read the diffuse color
	vec4 DiffuseColor = texture(uDiffuseTexture, inUV);
    
    // Convert ambient from gamma to linear
    vec3 ambient = pow(pushConsts.ambient_color.rgb, vec3(2.20f));

	// Set the global constribution
	finalColor.rgb = ambient * DiffuseColor.rgb * texture(uAmbientTexture, inUV).rgb;

    outFragColor = finalColor;
    outFragColor.a = DiffuseColor.a;
}

