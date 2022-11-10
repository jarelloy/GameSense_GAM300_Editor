#version 450

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]
layout (location = 2) in vec3 inNormal; //[INPUT_NORMAL]
layout (location = 3) in vec3 inTangent; //[INPUT_TANGENT]

layout (std140, push_constant) uniform PushConstants 
{
    mat4 model_matrix;
	vec4 world_eye_pos;
	vec4 ambient_color;
} pushConsts;

struct LightSource
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
};

layout(std140, binding = 5) uniform UBOViewProjection
{
    mat4 view_projection_matrix;
    LightSource light_source_list[1000];
    int num_light_source;
} uniforms;

layout(location = 0) out struct { 
    mat3 TBN;
    vec3 VertPos;
    vec2 UV;
} Out;

void main() 
{
    // Calculate Binormal
    vec3 binormal = normalize(cross(inTangent, inNormal));

    // Store TBN matrix
    Out.TBN = mat3(inTangent, binormal, inNormal);
    Out.VertPos = inPos;

    Out.UV = inUV;
    gl_Position = uniforms.view_projection_matrix * pushConsts.model_matrix * vec4(inPos, 1.0f);
}
