#version 460
layout(location = 0) in struct {
    vec3 Normal;
    vec2 UV;
    vec3 WorldPos;
    vec3 Tangent;
} In;

layout (location = 0) out vec4 outPos;
layout (location = 1) out vec4 outDiffuse;
layout (location = 2) out vec4 outNormal;
layout (location = 3) out vec4 outAmbient;
layout (location = 4) out vec4 outRoughness;
layout (location = 5) out vec4 outGlossiness;

layout (binding = 5) uniform sampler2D uDiffuseTexture;
layout (binding = 6) uniform sampler2D uNormalTexture;
layout (binding = 7) uniform sampler2D uAmbientTexture;
layout (binding = 8) uniform sampler2D uRoughnessTexture;
layout (binding = 9) uniform sampler2D uGlossinessTexture;

void main() 
{
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

    // Read the texture colors
	outDiffuse	= texture(uDiffuseTexture, In.UV);

    outAmbient = texture(uAmbientTexture, In.UV);

    outRoughness = texture(uRoughnessTexture, In.UV);

    outGlossiness = texture(uGlossinessTexture, In.UV);
}

