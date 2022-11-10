const uint CONE = 0;
const uint BOX = 1;
const uint SPHERE = 2;
const uint CIRCLE = 3;
const uint RECTANGLE = 4;

const uint BASE = 0;
const uint VOLUME = 1;
const uint SHELL = 2;
const uint EDGE = 3;

const uint WORLD = 0;
const uint SHAPE = 1;

const uint LOCAL = 1;

const uint WHOLE_SHEET = 0;
const uint RANDOM_ROW = 1;
const uint CUSTOM_FRAMES = 2;

const uint LIFETIME = 0;
const uint FPS = 1;

const uint BILLBOARD = 0;
const uint HORIZONTAL_BILLBOARD = 1;
const uint VERTICAL_BILLBOARD = 2;
const uint MESH = 3;

struct Particle
{
	vec2 m_Lifetime;		// Remaining/Max lifetime
	vec4 m_Color;			// Current color
	vec4 m_EndColor;		// End color
	vec3 m_Position;		// Current Position
	vec3 m_Rotation;		// Current Rotation
	vec3 m_RotationOverLifetime;		// Change in rotation
	vec3 m_Size;			// Current Size
	vec3 m_SizeOverLifetime;// Change in size
	vec3 m_Velocity;		// Current Velocity
	vec3 m_OrbitalVelocity; // Current Orbital Velocity
	vec3 m_OrbitalOffset;   // Current Orbital Offset
	vec3 m_Forces;			// Current Forces
	mat3 m_AlignMat;		// Matrix to align to initial direction
	float m_GravityModifier;// Gravity
	float m_RadialVelocity; // Radial Velocity
	float m_SpeedModifier;  // Speed Modifier
	ivec2 m_AnimationFrames;// Frames in animation
	int m_CurrentAnimationFrame;	// Current frame in animation
	float m_FPS;			// FPS / Use Lifetime
};

struct Shape
{
	int m_Enabled;
	int m_Type;

	float m_Angle;			// Angle of cone
	float m_Radius;			// Radius for Cone/Sphere/Circle
	float m_RadiusThickness;// Radius thickness
	vec3 m_BoxThickness;	// Box thickness
	float m_Arc;			// Arc angle for Cone
	float m_Length;			// Length of Cone
	vec3 m_Position;		// Position of emitter shape
	vec3 m_Rotation;		// Rotation of emitter shape
	vec3 m_Scale;			// Scale of emitter shape
	int m_EmitFrom;			// Emit from?

	int m_AlignToDirection;		// False means particles generated always facing camera
	float m_RandomizeDirection;	// Amount of direction to randomize
	float m_SpherizeDirection;	// Amount of direction to spherize
	float m_RandomizePosition;	// Amount of position to randomize
};

struct VelocityOverLifetime
{
	int m_Enabled;

	vec3 m_LinearValue1;
	vec3 m_LinearValue2;
	int m_LinearRandom;

	int m_Space;

	vec3 m_OrbitalValue1;
	vec3 m_OrbitalValue2;
	int m_OrbitalRandom;

	vec3 m_OffsetValue1;
	vec3 m_OffsetValue2;
	int m_OffsetRandom;

	float m_RadialValue1;
	float m_RadialValue2;
	int m_RadialRandom;

	float m_SpeedModifierValue1;
	float m_SpeedModifierValue2;
	int m_SpeedModifierRandom;
};

struct ForceOverLifetime
{
	int m_Enabled;

	vec3 m_ForceValue1;
	vec3 m_ForceValue2;
	int m_ForceRandom;

	int m_Space;
};

struct ColorOverLifetime
{
	int m_Enabled;

	vec4 m_ColorValue1;
	vec4 m_ColorValue2;
	int m_ColorRandom;
};

struct SizeOverLifetime
{
	int m_Enabled;

	vec3 m_SizeValue1;
	vec3 m_SizeValue2;
	int m_SizeRandom;
};

struct RotationOverLifetime
{
	int m_Enabled;

	vec3 m_RotationValue1;
	vec3 m_RotationValue2;
	int m_RotationRandom;
};

struct TextureSheetAnimation
{
	int m_Enabled;
	ivec2 m_Tiles;
	int m_Animation;
	ivec2 m_AnimationFrames;

	int m_StartFrameValue1;
	int m_StartFrameValue2;
	int m_StartFrameRandom;

	int m_TimeMode;

	float m_FPSValue1;
	float m_FPSValue2;
	int m_FPSRandom;

	int m_Looping;
};

struct Renderer
{
	int m_RenderMode;
	int m_RenderAlignment;
};
