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

void main() 
{
    const float Gamma = pushConsts.world_eye_pos.w;
	vec4 color = texture(uDiffuseTexture, In.UV) * pushConsts.color;

    // Read the texture colors
	outFragColor = vec4(pow(color.rgb, vec3(1.0f/Gamma)), color.a);
}

