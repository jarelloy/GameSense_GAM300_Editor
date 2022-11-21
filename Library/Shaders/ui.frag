#version 460

layout(location = 0) in struct {
    vec2 UV;
} In;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 color;
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

layout (binding = 5) uniform sampler2D uDiffuseTexture;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
    // Read the texture colors
	outFragColor = texture(uDiffuseTexture, In.UV);
	outFragColor = vec4(outFragColor.rgb * ToLinear(pushConsts.color.rgb), outFragColor.a * pushConsts.color.a);
}

