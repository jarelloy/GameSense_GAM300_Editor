#version 460

layout(location = 0) in struct {
    vec2 UV;
    vec4 Color;
} In;

layout (location = 0) out vec4 outFragColor;

layout (binding = 5) uniform sampler2D uDiffuseTexture;

void main() 
{
    // Read the texture colors
    float alpha = texture(uDiffuseTexture, In.UV).r;

	outFragColor = vec4(1.f, 1.f, 1.f, alpha) * vec4(pow(In.Color.rgb, vec3(2.20f)), In.Color.a);
}

