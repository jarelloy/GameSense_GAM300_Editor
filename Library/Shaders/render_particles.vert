#version 460
#extension GL_GOOGLE_include_directive : enable
#include "simplex_noise.glsl"
#include "particle_modules.glsl"
layout (location = 0) in vec3 inPos;    //[INPUT_POSITION]
layout (location = 1) in vec2 inUV;     //[INPUT_UVS]

layout(std430, binding = 0) buffer ParticleEngine_t
{
	vec3 m_Position;
	vec3 m_Rotation;
	vec3 m_Scale;

	// Initial Lifetime of particles
	float m_StartLifetimeValue1;		
	float m_StartLifetimeValue2;		
	int m_StartLifetimeRandom;			

	// Initial Speed of particles (not direction)
	float m_StartSpeedValue1;			
	float m_StartSpeedValue2;			
	int m_StartSpeedRandom;
	
	// Initial Size of particles
	vec3 m_StartSizeValue1;
	vec3 m_StartSizeValue2;
	int m_StartSizeRandom;

	// Initial Rotation of particles
	vec3 m_StartRotationValue1;
	vec3 m_StartRotationValue2;
	int m_StartRotationRandom;

	// Initial Color of particles
	vec4 m_StartColorValue1;
	vec4 m_StartColorValue2;
	int m_StartColorRandom;

	// Gravity inflicted on particles
	float m_GravityModifierValue1;
	float m_GravityModifierValue2;
	int m_GravityModifierRandom;

	int m_ScalingMode;	// Scaling Mode

	// Shape
	Shape m_Shape;

	// Velocity Overtime
	VelocityOverLifetime m_VelocityOverLifetime;

	// Force Overtime
	ForceOverLifetime m_ForceOverLifetime;

	// Color Overtime
	ColorOverLifetime m_ColorOverLifetime;

	// Size Overtime
	SizeOverLifetime m_SizeOverLifetime;

	// Rotation Overtime
	RotationOverLifetime m_RotationOverLifetime;

	// Texture Sheet Animation
	TextureSheetAnimation m_TextureSheetAnimation;

	// Renderer
	Renderer m_Renderer;

} ParticleEngine;

layout(std430, binding = 1) buffer ParticleBuffer_t
{
	Particle particles[];
} ParticleBuffer;

layout(std430, binding = 5) buffer ParticleAlivePreSimIndices_t
{
    uint indices[];
} AliveIndicesPreSim;

layout(std430, binding = 6) buffer ParticleAlivePostSimIndices_t
{
    uint indices[];
} AliveIndicesPostSim;

layout(std140, binding = 4) uniform CameraUBO
{
    mat4 view;
    mat4 projection;
} uboCamera;

layout (binding = 7) uniform sampler2D uDiffuseTexture;

layout (std140, push_constant) uniform PushConstants 
{
	vec3 camera_pos;
	vec4 ambient_color;
    vec2 viewport_size;
    int aligntodirection;
    int presimIdx;
    int postsimIdx;
    int user_param4;
    int user_param5;
    int user_param6;
    mat4 rotate_matrix;
} pushConsts;

layout(location = 0) out struct { 
    vec2 UV;
    vec4 Color;
} Out;

mat4 rotate(float angle, vec3 v)
{
    const float a = angle;
	const float c = cos(a);
	const float s = sin(a);

	vec3 axis = normalize(v);
	vec3 temp = (1.0 - c) * axis;

	mat4 Rotate;
	Rotate[0][0] = c + temp[0] * axis[0];
	Rotate[0][1] = temp[0] * axis[1] + s * axis[2];
	Rotate[0][2] = temp[0] * axis[2] - s * axis[1];

	Rotate[1][0] = temp[1] * axis[0] - s * axis[2];
	Rotate[1][1] = c + temp[1] * axis[1];
	Rotate[1][2] = temp[1] * axis[2] + s * axis[0];

	Rotate[2][0] = temp[2] * axis[0] + s * axis[1];
	Rotate[2][1] = temp[2] * axis[1] - s * axis[0];
	Rotate[2][2] = c + temp[2] * axis[2];

    mat4 m = mat4(1.0);
	mat4 Result;
	Result[0] = m[0] * Rotate[0][0] + m[1] * Rotate[0][1] + m[2] * Rotate[0][2];
	Result[1] = m[0] * Rotate[1][0] + m[1] * Rotate[1][1] + m[2] * Rotate[1][2];
	Result[2] = m[0] * Rotate[2][0] + m[1] * Rotate[2][1] + m[2] * Rotate[2][2];
	Result[3] = m[3];
	return Result;
}

mat3 rotateX(float angle)
{
	return mat3(vec3(1.0, 0.0, 0.0),vec3(0.0, cos(angle), sin(angle)),vec3(0.0, -sin(angle), cos(angle)));
}

mat3 rotateY(float angle)
{
	return mat3(vec3(cos(angle), 0.0, -sin(angle)),vec3(0.0, 1.0, 0.0),vec3(sin(angle), 0.0, cos(angle)));
}

mat3 rotateZ(float angle)
{
	return mat3(vec3(cos(angle), sin(angle), 0.0), vec3(-sin(angle), cos(angle), 0.0), vec3(0.0, 0.0, 1.0));
}

mat3 rotateAlign(vec3 v1, vec3 v2)
{
    vec3 axis = cross( v1, v2 );

    const float cosA = dot( v1, v2 );
    const float k = 1.0f / (1.0 + cosA);

    mat3 result = mat3((axis.x * axis.x * k) + cosA,
                 (axis.y * axis.x * k) - axis.z, 
                 (axis.z * axis.x * k) + axis.y,
                 (axis.x * axis.y * k) + axis.z,  
                 (axis.y * axis.y * k) + cosA,      
                 (axis.z * axis.y * k) - axis.x,
                 (axis.x * axis.z * k) - axis.y,  
                 (axis.y * axis.z * k) + axis.x,  
                 (axis.z * axis.z * k) + cosA 
                 );

    return result;
}


float ToRadians(float angle)
{
	return (angle * PI) / 180.0;
}

void main() 
{
    uint index = 0;
    if (pushConsts.postsimIdx == 1)
        index = AliveIndicesPostSim.indices[gl_InstanceIndex];
    else
        index = AliveIndicesPreSim.indices[gl_InstanceIndex];

	// COLOR
    Particle particle = ParticleBuffer.particles[index];
    Out.Color = particle.m_Color;

	// UV
	if (ParticleEngine.m_TextureSheetAnimation.m_Enabled > 0)
	{
		int curr_frame = particle.m_CurrentAnimationFrame;
		int frame_x = curr_frame % ParticleEngine.m_TextureSheetAnimation.m_Tiles.x;
		int frame_y = curr_frame / ParticleEngine.m_TextureSheetAnimation.m_Tiles.x;
		vec2 img_size = vec2(textureSize(uDiffuseTexture, 0).xy);
		vec2 frame_size = vec2(
		img_size.x / ParticleEngine.m_TextureSheetAnimation.m_Tiles.x,
		img_size.y / ParticleEngine.m_TextureSheetAnimation.m_Tiles.y);
		vec2 uv00 = vec2(float(frame_x) * frame_size.x, float(frame_y) * frame_size.y);
		vec2 uv11 = vec2(uv00.x + frame_size.x, uv00.y + frame_size.y);
		uv00 = vec2(uv00.x / img_size.x, uv00.y / img_size.y);
		uv11 = vec2(uv11.x / img_size.x, uv11.y / img_size.y);
		Out.UV = vec2(uv00.x + (uv11.x - uv00.x) * inUV.x, uv00.y + (uv11.y - uv00.y) * inUV.y);
	}
	else
	{
		Out.UV = inUV;
	}

	// POS
    vec3 quad_pos = inPos;

    // Scale
    quad_pos.x *= particle.m_Size.x;
    quad_pos.y *= particle.m_Size.y;
    quad_pos.z *= particle.m_Size.z;

	if (ParticleEngine.m_Renderer.m_RenderMode == MESH)
	{
		// Align to direction
		quad_pos = particle.m_AlignMat * quad_pos;

		// Rotate
		quad_pos =  rotateZ(ToRadians(particle.m_Rotation.z)) * 
					rotateY(ToRadians(particle.m_Rotation.y)) * 
					rotateX(ToRadians(particle.m_Rotation.x)) * 
					quad_pos;

		// Translate
		quad_pos += particle.m_Position.xyz;

		quad_pos = vec3(uboCamera.view * vec4(quad_pos, 1.0));
	}
	else if (ParticleEngine.m_Renderer.m_RenderMode == BILLBOARD)
	{
		if (ParticleEngine.m_Renderer.m_RenderAlignment == LOCAL)
		{
			// Align to direction
			quad_pos = particle.m_AlignMat * quad_pos;

			// Rotate
			quad_pos =  rotateZ(ToRadians(particle.m_Rotation.z)) * 
						rotateY(ToRadians(particle.m_Rotation.y)) * 
						rotateX(ToRadians(particle.m_Rotation.x)) * 
						quad_pos;

			// Translate
			quad_pos += particle.m_Position.xyz;

			quad_pos = vec3(uboCamera.view * vec4(quad_pos, 1.0));
		}
		else
		{
			// Rotate
			quad_pos =  rotateZ(ToRadians(particle.m_Rotation.z)) * 
						rotateY(ToRadians(particle.m_Rotation.y)) * 
						rotateX(ToRadians(particle.m_Rotation.x)) * 
						quad_pos;

			quad_pos += vec3(uboCamera.view * vec4(particle.m_Position.xyz, 1.0));
		}
	}
	else if (ParticleEngine.m_Renderer.m_RenderMode == HORIZONTAL_BILLBOARD)
	{
		// Rotate
		quad_pos =  rotateX(ToRadians(90.0)) * 
					quad_pos;

		// Translate
		quad_pos += particle.m_Position.xyz;

		quad_pos = vec3(uboCamera.view * vec4(quad_pos, 1.0));
	}
	else if (ParticleEngine.m_Renderer.m_RenderMode == VERTICAL_BILLBOARD)
	{
		vec3 direction = pushConsts.camera_pos - ParticleEngine.m_Position;
		direction.y = 0.0;

		// Rotate
		quad_pos =  rotateAlign(normalize(direction), vec3(0.0, 0.0, 1.0)) * 
					quad_pos;

		// Translate
		quad_pos += particle.m_Position.xyz;

		quad_pos = vec3(uboCamera.view * vec4(quad_pos, 1.0));
	}
    gl_Position = uboCamera.projection * vec4(quad_pos, 1.0);

    //if (particle.m_Velocity.x < 0 || particle.m_Velocity.y > 0)
        //gl_Position = vec4(0.0);
}
