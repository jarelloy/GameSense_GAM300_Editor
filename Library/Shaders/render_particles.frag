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

layout (binding = 3) uniform sampler2D uDepthTexture;
layout (binding = 7) uniform sampler2D uDiffuseTexture;

void main() 
{
	vec2 uv = vec2(gl_FragCoord.x / pushConsts.viewport_size.x, (gl_FragCoord.y / pushConsts.viewport_size.y));
	if (gl_FragCoord.z > texture(uDepthTexture, uv).r)
		discard;

    // Read the texture colors
    vec4 color = In.Color * texture(uDiffuseTexture, In.UV);
    //color.rgb *= color.a;
	outDiffuse = color;
}

