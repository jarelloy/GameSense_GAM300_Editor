#version 460

layout (location = 0) out float Depth;

layout(location = 0) in float fragDepth;

void main() 
{
	Depth = fragDepth;
}

