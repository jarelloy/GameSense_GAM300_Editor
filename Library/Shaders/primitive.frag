#version 460

layout(location = 0) in struct {
    vec4 VertColor;
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

layout (binding = 3) uniform sampler2D uDepthTexture;

layout (location = 0) out vec4 outFragColor;

vec3 ToGamma(vec3 color)
{
    return pow(color, vec3(1.0f / 2.20f));
}

void main() 
{
    outFragColor = In.VertColor;
}

