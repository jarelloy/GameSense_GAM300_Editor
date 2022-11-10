#version 450

layout(location = 0) in struct { 
    mat3 TBN;
    vec3 VertPos;
    vec2 UV;
} In;

struct LightSource
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
};

layout (std140, push_constant) uniform PushConstants 
{
    mat4 model_matrix;
	vec4 world_eye_pos;
	vec4 ambient_color;
} pushConsts;


layout (location = 0) out vec4 outFragColor;

layout (binding = 0) uniform sampler2D uDiffuseTexture;
layout (binding = 1) uniform sampler2D uNormalTexture;
layout (binding = 2) uniform sampler2D uAmbientTexture;
layout (binding = 3) uniform sampler2D uRoughnessTexture;
layout (binding = 4) uniform sampler2D uGlossinessTexture;

layout(std140, binding = 5) uniform UBOViewProjection
{
    mat4 view_projection_matrix;
    LightSource light_source_list[1000];
    int num_light_source;
} uniforms;

void main() 
{
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

    normal = normalize(In.TBN * normal);

    vec4 finalColor = vec4(0, 0, 0, 0);

    // Read the diffuse color
	vec4 DiffuseColor	= texture(uDiffuseTexture, In.UV);

	// Set the global constribution
	finalColor.rgb = pushConsts.ambient_color.rgb * DiffuseColor.rgb * texture(uAmbientTexture, In.UV).rgb;

    for (int i = 0; i < uniforms.num_light_source; ++i)
    {        
        // Note that the real light direction is the negative of this, but the negative is removed to speed up the equations
        vec4 LocalSpaceLightPos = inverse(pushConsts.model_matrix) * vec4(uniforms.light_source_list[i].position, 1.0);
	    vec3 LightDirection = normalize(LocalSpaceLightPos.xyz - In.VertPos );

	    // Compute the diffuse intensity
	    float DiffuseI  = max( 0, dot(normal, LightDirection ));

	    // Note This is the true Eye to Texel direction 
        vec4 LocalSpaceEyePos = inverse(pushConsts.model_matrix) * vec4(pushConsts.world_eye_pos.xyz, 1.0);
	    vec3 EyeDirection = normalize( In.VertPos - LocalSpaceEyePos.xyz );

        // Determine the power for the specular based on how rough something is
        const float Shininess = mix( 1, 100, 1 - texture( uRoughnessTexture, In.UV).r );
        float SpecularI2  = pow( max( 0, dot(normal, normalize( LightDirection - EyeDirection ))), Shininess );

	    // Add the contribution of this light
        finalColor.rgb += uniforms.light_source_list[i].intensity * uniforms.light_source_list[i].color.rgb * ( SpecularI2.rrr * texture(uGlossinessTexture, In.UV).rgb + DiffuseI.rrr * DiffuseColor.rgb );
    }
    const float Gamma = pushConsts.world_eye_pos.w;
	finalColor.a   = DiffuseColor.a;
	finalColor.rgb = pow( finalColor.rgb, vec3(1.0f/Gamma) );

    outFragColor = finalColor;
}

