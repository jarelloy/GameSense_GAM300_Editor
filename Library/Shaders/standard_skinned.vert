#version 460
layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]
layout (location = 2) in vec3 inNormal; //[INPUT_NORMAL]
layout (location = 3) in vec3 inTangent; //[INPUT_TANGENT]
layout (location = 4) in uvec4 inBoneIDs; //[INPUT_BONEIDS]
layout (location = 5) in vec4 inWeights; //[INPUT_WEIGHTS]

const int MAX_BONES = 200;

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

struct ModelData{
    mat4 bones_matrices[MAX_BONES];
};

layout(std140, binding = 1) readonly buffer ModelDataBuffer
{
    ModelData models[];
} modeldataBuffer;

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
    mat4 boneTransform = modeldataBuffer.models[objectBuffer.objects[gl_BaseInstance].model_id].bones_matrices[inBoneIDs[0]] * inWeights[0];
    boneTransform += modeldataBuffer.models[objectBuffer.objects[gl_BaseInstance].model_id].bones_matrices[inBoneIDs[1]] * inWeights[1];
    boneTransform += modeldataBuffer.models[objectBuffer.objects[gl_BaseInstance].model_id].bones_matrices[inBoneIDs[2]] * inWeights[2];
    boneTransform += modeldataBuffer.models[objectBuffer.objects[gl_BaseInstance].model_id].bones_matrices[inBoneIDs[3]] * inWeights[3];

    Out.WorldPos = vec3(objectBuffer.objects[gl_BaseInstance].model_matrix * boneTransform * vec4(inPos, 1.0f));
    Out.UV = inUV;

    // Normal in world space
	mat3 mNormal = transpose(inverse(mat3(objectBuffer.objects[gl_BaseInstance].model_matrix)));
	Out.Normal = mNormal * vec3(boneTransform * vec4(normalize(inNormal), 0.0));	
	Out.Tangent = mNormal * vec3(boneTransform * vec4(normalize(inTangent), 0.0));
    
    gl_Position = uboCamera.projection * uboCamera.view * vec4(Out.WorldPos, 1.0f);
}
