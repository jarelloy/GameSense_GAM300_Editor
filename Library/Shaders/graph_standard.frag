#version 460
#extension GL_GOOGLE_include_directive : enable
#include "shadergraph_helpers.glsl"

layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} In;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos; // Stores View Direction
	vec4 ambient_color; // Stores Time -> time, dt, unscaled dt, smoothdelta
    vec2 viewport_size; // Stores 
    int user_param;
    int user_param2;
    int user_param3;
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;

layout(std430, binding = 2) buffer ParamUBO
{
    ParamCode} paramUBO;

SamplerCode

layout (location = 0) out vec4 outPos;
layout (location = 1) out vec4 outDiffuse;
layout (location = 2) out vec4 outNormal;
layout (location = 3) out vec4 outAmbient;
layout (location = 4) out vec4 outRoughness;
layout (location = 5) out vec4 outGlossiness;
layout (location = 6) out vec4 outEmissive;

void main() 
{
    // Calculate normal in tangent space
	vec3 N = normalize(In.Normal);
	vec3 T = normalize(In.Tangent);
	vec3 B = cross(N, T);
	mat3 TBN = mat3(T, B, N);

    outPos = vec4(In.WorldPos, 1.0);

	ShaderCode
	
    if (_Albedo_.a <= _AlphaClipThreshold_) {
        discard;
    }

    _Albedo_.a = 1.0;
    outDiffuse = _Albedo_;
    outNormal = vec4(_Normal_, 1.0);
    outAmbient = vec4(_Ambient_);
    outRoughness = vec4(_Roughness_);
    outGlossiness = vec4(_Glossiness_);
    outEmissive = vec4(_Emissive_.rgb * _Emissive_.a, 1.0);
}

