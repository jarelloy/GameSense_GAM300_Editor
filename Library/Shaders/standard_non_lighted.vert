#version 460

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]
layout (location = 2) in vec3 inNormal; //[INPUT_NORMAL]
layout (location = 3) in vec3 inTangent; //[INPUT_TANGENT]

struct ObjectData{
	mat4 model_matrix;
    uint model_id;
    uint obj_index;
};

//all object matrices
layout(std140, binding = 0) readonly buffer ObjectBuffer
{
	ObjectData objects[];
} objectBuffer;

layout(std140, binding = 4) uniform CameraUBO
{
    mat4 view;
    mat4 projection;
} uboCamera;

layout(location = 0) out struct { 
    vec2 UV;
} Out;

void main() 
{
    Out.UV = inUV;

    gl_Position = uboCamera.projection * uboCamera.view * objectBuffer.objects[gl_BaseInstance].model_matrix * vec4(inPos, 1.0f);
}
