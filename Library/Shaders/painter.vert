#version 460
layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]

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

layout (location = 0) flat out uint ObjID;

void main() 
{
    ObjID = objectBuffer.objects[gl_BaseInstance].obj_index;    
    gl_Position = uboCamera.projection * uboCamera.view * objectBuffer.objects[gl_BaseInstance].model_matrix * vec4(inPos, 1.0f);
}
