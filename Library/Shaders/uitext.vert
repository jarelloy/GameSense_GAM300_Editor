#version 460

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]
layout (location = 2) in vec4 inColor;  //[INPUT_COLOR]

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
    mat4 view_projection_matrix;
} pushConsts;

layout(location = 0) out struct { 
    vec2 UV;
    vec4 Color;
} Out;

void main() 
{
    Out.UV = inUV;
    Out.Color = inColor;

    gl_Position = pushConsts.view_projection_matrix * vec4(inPos, 1.0f);
}
