#version 460
#extension GL_GOOGLE_include_directive : enable
#include "random.glsl"

layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} In;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos; // Stores View Direction
	vec4 ambient_color; // Stores 
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

float saturate(float v) { return clamp(v, 0.0,       1.0);       }
vec2  saturate(vec2  v) { return clamp(v, vec2(0.0), vec2(1.0)); }
vec3  saturate(vec3  v) { return clamp(v, vec3(0.0), vec3(1.0)); }
vec4  saturate(vec4  v) { return clamp(v, vec4(0.0), vec4(1.0)); }

float fresnelEffect(vec3 normal, vec3 viewDir, float power)
{
    return pow((1.0 - saturate(dot(normal, normalize(viewDir)))), power);
}

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

