#version 460
layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} In;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos; // Stores Diffuse Tint
	vec4 ambient_color; // Stores Emissive Values
    vec2 viewport_size; // Stores Glossiness / Roughness
    int user_param;
    int user_param2;
    int user_param3;
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;

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

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

void main() 
{
    vec4 diffuse = texture(uDiffuseTexture, In.UV) * vec4(ToLinear(pushConsts.world_eye_pos.rgb), pushConsts.world_eye_pos.a);
    if (diffuse.a < 0.01){
        discard;
    }
    diffuse.a = 1.0;

    outPos = vec4(In.WorldPos, 1.0);

    // Calculate normal in tangent space
	vec3 N = normalize(In.Normal);
	vec3 T = normalize(In.Tangent);
	vec3 B = cross(N, T);
	mat3 TBN = mat3(T, B, N);

    // obtain normal from normal map in range [0,1]
    // vec3 normal = texture(uNormalTexture, In.UV).rgb;
    // transform normal vector to range [-1,1]
    // normal = normal * 2.0 - 1.0;

    // For Compressed Normals:
    vec3 normal;
	// For BC5 it used (rg)
	normal.xy	= (texture(uNormalTexture, In.UV).gr * 2.0) - 1.0;
	
	// Derive the final element
	normal.z =  sqrt(1.0 - dot(normal.xy, normal.xy));

    vec3 tnorm = normalize(TBN * normal);
    outNormal = vec4(tnorm, 1.0);

	outDiffuse = diffuse;

    outAmbient = texture(uAmbientTexture, In.UV);

    outRoughness = texture(uRoughnessTexture, In.UV) * pushConsts.viewport_size.y;

    outGlossiness = texture(uGlossinessTexture, In.UV) * pushConsts.viewport_size.x;

    outEmissive = texture(uEmissiveTexture, In.UV) * vec4(ToLinear(pushConsts.ambient_color.rgb) * pushConsts.ambient_color.a, 1.f);
}

