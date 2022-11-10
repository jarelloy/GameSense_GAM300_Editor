#version 460

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec4 inColor;  //[INPUT_COLOR]

layout(std140, binding = 4) uniform CameraUBO
{
    mat4 view;
    mat4 projection;
} uboCamera;

layout(location = 0) out struct { 
    vec4 VertColor;
} Out;

void main() 
{
    Out.VertColor = inColor;
    gl_Position = uboCamera.projection * uboCamera.view * vec4(inPos, 1.0f);
}
