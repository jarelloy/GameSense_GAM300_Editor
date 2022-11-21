#version 460

layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]

struct ObjectData{
	mat4 model_matrix;
    uint model_id;
    uint obj_index;
};

//all object matrices
layout(std140, binding = 0) readonly buffer ObjectBuffer
{
	ObjectData objects[];
} objectBuffer;

struct DirectionalLight
{
    vec3 position;  //Using vec3s in GLSL will just be aligned to a vec4
    vec4 color;
    float intensity;
    float far_plane;
    int cast_shadows;
    mat4 viewMatrix;
};

layout(std140, binding = 2) uniform UBOLights
{
    DirectionalLight directional_light_list[500];
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

void main()
{
	gl_Position = uniforms.directional_light_list[pushConsts.user_param].viewMatrix * objectBuffer.objects[gl_BaseInstance].model_matrix * vec4(inPos, 1.0f);
}
