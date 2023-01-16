#version 460
layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} In;

layout(std430, binding = 2) buffer ParamUBO
{
    ParamCode} paramUBO;

layout (location = 0) out vec4 outPos;
layout (location = 1) out vec4 outDiffuse;
layout (location = 2) out vec4 outNormal;
layout (location = 3) out vec4 outAmbient;
layout (location = 4) out vec4 outRoughness;
layout (location = 5) out vec4 outGlossiness;
layout (location = 6) out vec4 outEmissive;

layout (binding = 5) uniform sampler2D uDiffuseTexture;
layout (binding = 6) uniform sampler2D uNormalTexture;
layout (binding = 7) uniform sampler2D uAmbientTexture;
layout (binding = 8) uniform sampler2D uRoughnessTexture;
layout (binding = 9) uniform sampler2D uGlossinessTexture;
layout (binding = 10) uniform sampler2D uEmissiveTexture;

void main() 
{
    outPos = vec4(In.WorldPos, 1.0);

	ShaderCode
	outDiffuse = Albedo0;
    outNormal = vec4(Normal0, 0.0);
    outAmbient = vec4(Ambient0);
    outRoughness = vec4(Roughness0);
    outGlossiness = vec4(Glossiness0);
    outEmissive = Emissive0;
}

