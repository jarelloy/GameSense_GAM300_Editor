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
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} Out;

void main() 
{
    Out.WorldPos = vec3(objectBuffer.objects[gl_BaseInstance].model_matrix * vec4(inPos, 1.0f));
    Out.UV = inUV;

    // Normal in world space
	mat3 mNormal = transpose(inverse(mat3(objectBuffer.objects[gl_BaseInstance].model_matrix)));
	Out.Normal = mNormal * normalize(inNormal);	
	Out.Tangent = mNormal * normalize(inTangent);
    
    gl_Position = uboCamera.projection * uboCamera.view * objectBuffer.objects[gl_BaseInstance].model_matrix * vec4(inPos, 1.0f);
}
