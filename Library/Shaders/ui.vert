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
    int frameX = pushConsts.user_param % pushConsts.user_param2;
    int frameY = pushConsts.user_param / pushConsts.user_param3;
    vec2 frameSize = vec2(1.0 / pushConsts.user_param2, 1.0 / pushConsts.user_param3);
    vec2 frameUV00 = frameSize * vec2(frameX, frameY);
    vec2 ssUVxbounds = vec2(frameUV00.x, frameUV00.x + frameSize.x);
    vec2 ssUVybounds = vec2(frameUV00.y, frameUV00.y + frameSize.y);
    Out.UV = vec2(
        remap(inUV.x, vec2(0.0, 1.0), ssUVxbounds), 
        remap(inUV.y, vec2(0.0, 1.0), ssUVybounds)
    );

    Out.UV = vec2(
        remap(Out.UV.x, ssUVxbounds, ssUVxbounds.xx + pushConsts.world_eye_pos.xz * frameSize.x), 
        remap(Out.UV.y, ssUVybounds, ssUVybounds.xx + pushConsts.world_eye_pos.yw * frameSize.y)
    );

    gl_Position = pushConsts.view_projection_matrix * vec4(inPos, 1.0f);
}
