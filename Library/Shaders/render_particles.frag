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

vec3 ToGamma(vec3 color)
{
    return pow(color, vec3(1.0 / 2.20f));
}

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
    // Read the texture colors
	outDiffuse = In.Color * texture(uDiffuseTexture, In.UV);
    //outDiffuse = vec4(ToLinear(outDiffuse.rgb), outDiffuse.a);
}

