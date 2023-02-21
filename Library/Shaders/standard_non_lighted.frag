#version 460

layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
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

layout (binding = 5) uniform sampler2D uDiffuseTexture;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
    vec4 diffuseTint = vec4(ToLinear(pushConsts.world_eye_pos.rgb), pushConsts.world_eye_pos.a);

    // Read the texture colors
	outDiffuse = texture(uDiffuseTexture, In.UV) * diffuseTint;
}

