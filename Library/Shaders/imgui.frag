#version 450

struct InStruct
{
    vec4 Color;
    vec2 UV;
};

layout(set = 0, binding = 0) uniform sampler2D sTexture;

layout(location = 0) out vec4 fColor;
layout(location = 0) in InStruct In;

void main()
{
    fColor = In.Color * texture(sTexture, In.UV);
}