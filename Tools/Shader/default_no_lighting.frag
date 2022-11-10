#version 450

layout(location = 0) in struct { vec4 Color; vec2 UV; } In;

layout (location = 0) out vec4 outFragColor;

layout (binding = 0) uniform sampler2D uSamplerColor;

void main() 
{
	// Output color
	vec4 finalColor = In.Color * texture(uSamplerColor, In.UV);
	//if(finalColor.a < 0.01)
		//discard;
	outFragColor = finalColor;
}

