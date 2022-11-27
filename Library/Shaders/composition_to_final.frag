#version 460

#define EPSILON 1e-10
#define LUMINANCE_PRESERVATION 1.0

layout (location = 0) in vec2 inUV;

layout (std140, push_constant) uniform PushConstants 
{
	vec4 world_eye_pos;
	vec4 bloom_color;
    vec2 viewport_size;
    int bloomEnabled;
    int user_param2;
	int user_param3;
	int user_param4;
    int user_param5;
    int user_param6;
    mat4 shadow_matrix;
} pushConsts;

struct Bloom
{
	int m_Enabled;
	float m_Intensity;
	float m_Threshold;
	float m_SoftKnee; // 0.f to 1.f
	float m_Clamp;
	float m_Diffusion; // 0.f to 10.f
	float m_AnamorphicRatio; //  -1.f, 1.f
	float m_BlurScale; // 0.f to 10.f
	float m_BlurStrength;
	vec3 m_Color;
};
	
struct ColorGrading
{
	int m_Enabled;
	float m_Temperature; // -100 to 100
	float m_TempFactor; // 0 - 1
	float m_Tint; // -100 to 100
	float m_TintFactor; // 0 - 1
	vec3 m_ColorFilter;
	float m_HueShift;
	float m_Saturation;
	float m_Brightness;
	float m_Contrast;
};

struct Vignette
{
	int m_Enabled;
	vec4 m_Color;
	vec2 m_Center; // 0 - 1
	float m_Intensity;
	float m_Smoothness;
	float m_Roundness;
	int m_Rounded;
};

layout(std430, binding = 2) buffer PP_Buffer
{
    int m_Enabled;
	Bloom m_Bloom;
	ColorGrading m_ColorGrading;
	Vignette m_Vignette;
} pp_buffer;


layout (binding = 5) uniform sampler2D uFinalTexture;
layout (binding = 6) uniform sampler2D uBloomTexture;

layout (location = 0) out vec4 outFragColor;

vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

vec3 ApplyBloom(vec3 color)
{
    if (pp_buffer.m_Enabled == 1 && pp_buffer.m_Bloom.m_Enabled == 1)
    {
	    vec3 bloomColor = texture(uBloomTexture, inUV).rgb;
        color += bloomColor * ToLinear(pp_buffer.m_Bloom.m_Color) * pp_buffer.m_Bloom.m_Intensity;
    }
	return color;
}

float saturate(float v) { return clamp(v, 0.0,       1.0);       }
vec2  saturate(vec2  v) { return clamp(v, vec2(0.0), vec2(1.0)); }
vec3  saturate(vec3  v) { return clamp(v, vec3(0.0), vec3(1.0)); }
vec4  saturate(vec4  v) { return clamp(v, vec4(0.0), vec4(1.0)); }

vec3 ColorTemperatureToRGB(float temperature){
  // Values from: http://blenderartists.org/forum/showthread.php?270332-OSL-Goodness&p=2268693&viewfull=1#post2268693   
  mat3 m = (temperature <= 6500.0) ? mat3(vec3(0.0, -2902.1955373783176, -8257.7997278925690),
	                                      vec3(0.0, 1669.5803561666639, 2575.2827530017594),
	                                      vec3(1.0, 1.3302673723350029, 1.8993753891711275)) : 
	 								 mat3(vec3(1745.0425298314172, 1216.6168361476490, -8257.7997278925690),
   	                                      vec3(-2666.3474220535695, -2173.1012343082230, 2575.2827530017594),
	                                      vec3(0.55995389139931482, 0.70381203140554553, 1.8993753891711275)); 
  return mix(clamp(vec3(m[0] / (vec3(clamp(temperature, 1000.0, 40000.0)) + m[1]) + m[2]), vec3(0.0), vec3(1.0)), vec3(1.0), smoothstep(1000.0, 0.0, temperature));
}

vec3 applyTemperature(vec3 color, float temperature, float tempfactor, float tint, float tintfactor)
{
	vec3 colorTempRGB = ColorTemperatureToRGB(temperature);
	vec3 colorTintRGB = ColorTemperatureToRGB(tint);
    colorTintRGB = vec3(colorTintRGB.b, colorTintRGB.r, colorTintRGB.g);

	vec3 blendedTemp = mix(color, color * colorTempRGB, tempfactor);
	blendedTemp *= mix(1.0, dot(color, vec3(0.2126, 0.7152, 0.0722)) / max(dot(color, vec3(0.2126, 0.7152, 0.0722)), 1e-5), LUMINANCE_PRESERVATION);
	
	vec3 blendedTint = mix(blendedTemp, blendedTemp * colorTintRGB, tintfactor);
	blendedTint *= mix(1.0, dot(color, vec3(0.2126, 0.7152, 0.0722)) / max(dot(color, vec3(0.2126, 0.7152, 0.0722)), 1e-5), LUMINANCE_PRESERVATION);

	return blendedTint;
}

vec3 applyHue(vec3 aColor, float aHue)
{
    float angle = radians(aHue);
    vec3 k = vec3(0.57735, 0.57735, 0.57735);
    float cosAngle = cos(angle);
    return aColor * cosAngle + cross(k, aColor) * sin(angle) + 
        k * dot(k, aColor) * (1 - cosAngle);
}

vec3 ApplyColorGrading(vec3 color)
{
	if (pp_buffer.m_Enabled == 1 && pp_buffer.m_ColorGrading.m_Enabled == 1)
    {
        float temperature = pp_buffer.m_ColorGrading.m_Temperature / 100.0;
        temperature = temperature < 0.0 ? 6550 + (40000 - 6550) * (-temperature) : 6550 + (1000 - 6550) * temperature;
        float tint = pp_buffer.m_ColorGrading.m_Tint / 100.0;
        tint = tint < 0.0 ? 6550 + (40000 - 6550) * (-tint) : 6550 + (1000 - 6550) * tint;
        color = applyTemperature(color, temperature, pp_buffer.m_ColorGrading.m_TempFactor, tint, pp_buffer.m_ColorGrading.m_TintFactor);

		color = ToLinear(pp_buffer.m_ColorGrading.m_ColorFilter) * color;
		vec4 hsbc = vec4(
		pp_buffer.m_ColorGrading.m_HueShift < 0.0 ? 360.0 + pp_buffer.m_ColorGrading.m_HueShift : pp_buffer.m_ColorGrading.m_HueShift, 
		(pp_buffer.m_ColorGrading.m_Saturation / 200.0) + 0.5, 
		(pp_buffer.m_ColorGrading.m_Brightness / 200.0) + 0.5,
		(pp_buffer.m_ColorGrading.m_Contrast / 200.0) + 0.5);

		float _Hue = hsbc.r;
		float _Saturation = hsbc.g * 2;
		float _Brightness = hsbc.b * 2 - 1;
		float _Contrast = hsbc.a * 2;

		color = applyHue(color, _Hue);
		color = (color - 0.5f) * (_Contrast) + 0.5f;
		color = color + _Brightness;
    
		float intensity_val = dot(color, vec3(0.2126, 0.7152, 0.0722));
		vec3 intensity = vec3(intensity_val, intensity_val, intensity_val);
		color = mix(intensity, color, _Saturation);
	}
    return color;
}

vec3 ApplyVignette(vec3 color)
{
	if (pp_buffer.m_Enabled == 1 && pp_buffer.m_Vignette.m_Enabled == 1)
    {
		// Rounded: * aspect ratio (x, y)

		float roundness = 0.1 + (pp_buffer.m_Vignette.m_Roundness) * (0.9);
		float intensity = min(pp_buffer.m_Vignette.m_Intensity, 0.99);
		float smoothness = min(pp_buffer.m_Vignette.m_Smoothness, 0.99);
		vec2 offset = pp_buffer.m_Vignette.m_Center - vec2(0.5);

		// Maps 0 to 1 -> -0.5 to 0.5 + offset
		vec2 uv = inUV - 0.5 + vec2(-offset.x, offset.y);

		if (pp_buffer.m_Vignette.m_Rounded == 1)
		{
			float aspect_ratio = pushConsts.viewport_size.x / pushConsts.viewport_size.y;
			if (pushConsts.viewport_size.x > pushConsts.viewport_size.y)
				uv.x *= aspect_ratio;
			else
				uv.y *= (1.0 / aspect_ratio);
		}

		//Calculate edge curvature
		vec2 curve = pow(abs(uv), vec2(1.0 / roundness));
		//Compute distance to edge
		float edge = pow(length(curve), roundness);

		float outerRadius = (1.0 - intensity);
		float innerRadius = outerRadius * smoothness;
		float vignette = smoothstep(outerRadius, innerRadius, edge) * pp_buffer.m_Vignette.m_Color.a;
		color = mix(color, pp_buffer.m_Vignette.m_Color.rgb, 1.0 - vignette);
	}
	return color;
}

void main() 
{
	vec4 hdrColor4 = texture(uFinalTexture, inUV);
	vec3 hdrColor = hdrColor4.rgb;

	hdrColor = ApplyBloom(hdrColor);
	
    const float Gamma = pushConsts.world_eye_pos.w;
    const float Exposure = pushConsts.world_eye_pos.x;

	// HDR to RGBUNORM
  
    // exposure tone mapping
    vec3 color = vec3(1.0) - exp(-hdrColor * Exposure);

    // gamma correction 
    color = pow(color, vec3(1.0 / Gamma));

    color = ApplyColorGrading(color);
    color = ApplyVignette(color);
  
	outFragColor = vec4(color, hdrColor4.a);
}