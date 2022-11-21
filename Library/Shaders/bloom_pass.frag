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

layout (binding = 5) uniform sampler2D uFinalTexture;

layout (location = 0) out vec4 outFragColor;

float ToLinear(float value)
{
    return pow(value, 2.20f);
}

void main() 
{

    vec3 hdrColor = texture(uFinalTexture, inUV).rgb;

    // Apply clamp
    hdrColor = clamp(hdrColor, 0.f, ToLinear(pushConsts.ambient_color.y));

    // Convert to grayscale and check brightness lvl
	float brightness = dot(hdrColor, vec3(0.2126, 0.7152, 0.0722));

    // Apply Softknee
    float threshold = ToLinear(pushConsts.ambient_color.x);
    float softKnee = pushConsts.ambient_color.z;

    float knee = threshold * softKnee;
    float soft = brightness - threshold + knee;
    soft = clamp(soft, 0, 2 * knee);
    soft = soft * soft / (4 * knee + 0.00001);
    float contribution = max(soft, brightness - threshold);
    contribution /= max(brightness, 0.00001);

    outFragColor = vec4(hdrColor * contribution, 1.0);

    // Check Threshold
    //if (brightness > threshold)
    //{
        //outFragColor = vec4(hdrColor, 1.0);
    //}
    //else
    //{
        //float softKnee = pushConsts.ambient_color.z;
        //float ratio = clamp(brightness / threshold, 0.f, 1.0);
        //outFragColor = vec4(hdrColor * ratio * (1.0 - softKnee), 1.0);
    //}
}