#version 460
#define EPSILON 1e-5

layout (location = 0) in vec2 inUV;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 bloom_color;
    vec2 viewport_size;
    int bloomEnabled;
    int user_param2;
	int user_param3;
	int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;

layout (binding = 5) uniform sampler2D uParticlesTexture;

layout (location = 0) out vec4 outFragColor;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
	vec4 color = texture(uParticlesTexture, inUV);
	outFragColor = vec4(ToLinear(color.rgb), color.a);
}