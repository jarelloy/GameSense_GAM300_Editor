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

layout (location = 0) out vec4 outDiffuse;

void main() 
{
    // Calculate normal in tangent space
	vec3 N = normalize(In.Normal);
	vec3 T = normalize(In.Tangent);
	vec3 B = cross(N, T);
	mat3 TBN = mat3(T, B, N);

	ShaderCode
	
    outDiffuse = _Albedo_;
}

