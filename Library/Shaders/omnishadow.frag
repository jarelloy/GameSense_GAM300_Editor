#version 460

layout(location = 0) in vec4 inFragPos;

struct PointLight
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
    float radius;
    float far_plane;
};

layout(std140, binding = 2) uniform UBOLights
{
    PointLight point_light_list[1000];
} uniforms;

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

layout (location = 0) out float Depth;

void main() 
{
     // get distance between fragment and light source
    float lightDistance = length(inFragPos.xyz - uniforms.point_light_list[pushConsts.user_param].position);
    
    // map to [0;1] range by dividing by far_plane
    lightDistance = lightDistance / uniforms.point_light_list[pushConsts.user_param].far_plane;
    
    // write this as modified depth
    Depth = lightDistance;
}

