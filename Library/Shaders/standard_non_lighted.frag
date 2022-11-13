#version 460

layout(location = 0) in struct {
    vec2 UV;
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

vec3 ToGamma(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
    vec4 diffuseTint = vec4(ToGamma(pushConsts.world_eye_pos.rgb), pushConsts.world_eye_pos.a);

    // Read the texture colors
    const float Gamma = pushConsts.world_eye_pos.w;
    vec4 diffuse = texture(uDiffuseTexture, In.UV) * diffuseTint;
	outDiffuse = vec4(pow(diffuse.rgb, vec3(1.0f/Gamma)), diffuse.a);
}

