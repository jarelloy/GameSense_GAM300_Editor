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

layout (binding = 3) uniform sampler2D uDepthTexture;
layout (binding = 5) uniform sampler2D uDiffuseTexture;

void main() 
{
	vec2 uv = vec2(gl_FragCoord.x / pushConsts.viewport_size.x, (gl_FragCoord.y / pushConsts.viewport_size.y));
	if (gl_FragCoord.z > texture(uDepthTexture, uv).r)
		discard;

    // Read the texture colors
    const float Gamma = pushConsts.world_eye_pos.w;
    vec4 diffuse = texture(uDiffuseTexture, In.UV);
	outDiffuse = vec4(pow(diffuse.rgb, vec3(1.0f/Gamma)), diffuse.a);
}

