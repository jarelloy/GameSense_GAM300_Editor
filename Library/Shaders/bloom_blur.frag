#version 460

layout (location = 0) in vec2 inUV;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 ambient_color;
    vec2 viewport_size;
    int horizontal;
    int user_param2;
	int user_param3;
	int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;

const float pi = 3.14159265;

layout (binding = 5) uniform sampler2D uBloomTexture;

layout (location = 0) out vec4 outFragColor;

const float weight[5] = {0.227027, 0.1945946, 0.1216216, 0.054054, 0.016216};

void main() 
{
    vec4 bloom = texture(uBloomTexture, inUV);
    vec2 tex_offset = 1.0 / textureSize(uBloomTexture, 0) * pushConsts.viewport_size.x; // gets size of single texel
    vec3 result = bloom.rgb * weight[0]; // current fragment's contribution
    if (pushConsts.horizontal == 1)
    {
        for (int i = 1; i < 5; ++i)
        {
            result += texture(uBloomTexture, inUV + vec2(tex_offset.x * i, 0.0)).rgb * weight[i] * pushConsts.viewport_size.y;
            result += texture(uBloomTexture, inUV - vec2(tex_offset.x * i, 0.0)).rgb * weight[i] * pushConsts.viewport_size.y;
        }
    }
    else
    {
        for (int i = 1; i < 5; ++i)
        {
            result += texture(uBloomTexture, inUV + vec2(0.0, tex_offset.y * i)).rgb * weight[i] * pushConsts.viewport_size.y;
            result += texture(uBloomTexture, inUV - vec2(0.0, tex_offset.y * i)).rgb * weight[i] * pushConsts.viewport_size.y;
        }
    }
    outFragColor = vec4(result, 1.0);
}