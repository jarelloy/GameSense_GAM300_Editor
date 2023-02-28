#version 460

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos; // Stores UV mapping
	vec4 ambient_color;
    vec2 viewport_size;
    int user_param; // Stores frameNo
    int user_param2;// Stores tilex
    int user_param3;// Stores tiley
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 view_projection_matrix;
} pushConsts;

layout(location = 0) out struct { 
    vec2 UV;
} Out;

float remap(float In, vec2 InMinMax, vec2 OutMinMax) { 
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}

void main() 
{
    Out.UV = vec2(remap(inUV.x, vec2(0.0, 1.0), pushConsts.world_eye_pos.xz), remap(inUV.y, vec2(0.0, 1.0), pushConsts.world_eye_pos.yw));

    int frameX = pushConsts.user_param % pushConsts.user_param2;
    int frameY = pushConsts.user_param / pushConsts.user_param3;
    vec2 frameSize = vec2(1.0 / pushConsts.user_param2, 1.0 / pushConsts.user_param3);
    vec2 frameUV00 = frameSize * vec2(frameX, frameY);
    Out.UV = vec2(
        remap(inUV.x, vec2(frameUV00.x, frameUV00.x + frameSize.x), pushConsts.world_eye_pos.xz), 
        remap(inUV.y, vec2(frameUV00.y, frameUV00.y + frameSize.y), pushConsts.world_eye_pos.yw)
    );

    gl_Position = pushConsts.view_projection_matrix * vec4(inPos, 1.0f);
}
