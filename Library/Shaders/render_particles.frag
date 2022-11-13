#version 460
layout(location = 0) in struct {
    vec2 UV;
    vec4 Color;
} In;

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

layout (location = 0) out vec4 outDiffuse;

layout (binding = 7) uniform sampler2D uDiffuseTexture;

void main() 
{
    // Read the texture colors
    vec4 color = In.Color * texture(uDiffuseTexture, In.UV);
    const float Gamma = pushConsts.world_eye_pos.w;
	outDiffuse = vec4(pow(color.rgb, vec3(1.0f/Gamma)), color.a);;
}

