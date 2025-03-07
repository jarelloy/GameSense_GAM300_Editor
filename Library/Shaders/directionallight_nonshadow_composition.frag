#version 460

layout (location = 0) in vec2 inUV;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 ambient_color;
    vec2 viewport_size;
    int user_param;
    int user_param2;
	int user_param3;
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;


layout (location = 0) out vec4 outFragColor;

layout (binding = 5) uniform sampler2D uPositionTexture;
layout (binding = 6) uniform sampler2D uDiffuseTexture;
layout (binding = 7) uniform sampler2D uNormalTexture;
layout (binding = 8) uniform sampler2D uAmbientTexture;
layout (binding = 9) uniform sampler2D uRoughnessTexture;
layout (binding = 10) uniform sampler2D uGlossinessTexture;
layout (binding = 11) uniform sampler2D uEmissiveTexture;

struct DirectionalLight
{
    vec3 direction;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
    float far_plane;
	int enabled;
    mat4 viewMatrix;
};

layout(std140, binding = 2) uniform UBOLights
{
    DirectionalLight directional_light_list[500];
} uniforms;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

float ToLinear(float value)
{
    return pow(value, 2.20f);
}

void main() 
{
    vec4 finalColor = vec4(0, 0, 0, 0);

    // Read the diffuse color
	vec4 DiffuseColor = texture(uDiffuseTexture, inUV);
    finalColor.a = DiffuseColor.a;

    // Read normal
    vec3 normal = vec3(texture(uNormalTexture, inUV));

    vec3 vertPos = vec3(texture(uPositionTexture, inUV));

	const float Shininess = mix( 1, 100, 1 - texture( uRoughnessTexture, inUV).r);

    vec3 glossiveness = texture(uGlossinessTexture, inUV).rgb;

	// Viewer to fragment
	vec3 EyeDirection =  vertPos - pushConsts.world_eye_pos.xyz;
	EyeDirection = normalize(EyeDirection);

    for (int i = pushConsts.user_param; i < pushConsts.user_param + pushConsts.user_param2; ++i)
    {        
		if (uniforms.directional_light_list[i].enabled == 0) continue;

		// Directional light color from gamma to linear
		vec3 light_color = pow(uniforms.directional_light_list[i].color.rgb, vec3(2.20f));

        // Vector to light
		vec3 LightDirection = uniforms.directional_light_list[i].direction;

	    // Compute the diffuse intensity
	    float DiffuseI  = max( 0, dot(normal, LightDirection ));
        vec3 ComputedDiffuse = DiffuseI.rrr * DiffuseColor.rgb;

        // Determine the power for the specular based on how rough something is
        float SpecularI2  = pow( max( 0, dot(normal, normalize( LightDirection - EyeDirection ))), Shininess );
        vec3 ComputedSpecular = SpecularI2.rrr * glossiveness;

	    // Add the contribution of this light
        finalColor.rgb += uniforms.directional_light_list[i].intensity * light_color * (ComputedDiffuse + ComputedSpecular);
    }

    outFragColor = finalColor;
}

