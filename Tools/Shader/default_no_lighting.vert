#version 450

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]
layout (location = 2) in vec3 inNormal;     //[INPUT_UVS]

//layout (location = 1) in vec4 inColor;  //[INPUT_COLOR]


layout (std140, push_constant) uniform Uniforms 
{
    mat4 model_matrix;
    mat4 view_matrix;
    mat4 projection_matrix;
} uniforms;

layout(location = 0) out struct { vec4 Color; vec2 UV; } Out;

void main() 
{
    Out.Color = vec4(1.0f, 1.0f, 1.0f, 1.0f);
    Out.UV = inUV;
    gl_Position = uniforms.projection_matrix * uniforms.view_matrix * uniforms.model_matrix * vec4(inPos, 1.0f);
}
