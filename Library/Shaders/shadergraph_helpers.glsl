const float C_EPSILON = 1e-3;
const float C_PI = 3.14159265358979323846264338327950288;
const float C_TAU = 6.28318530;
const float C_PHI = 1.618034;
const float C_EXP = 2.718282;
const float C_SQRT2 = 1.414214;
const float C_LOG10INV = 1.0 / log(10.0);

float saturate(float v) { return clamp(v, 0.0, 1.0); }
vec2  saturate(vec2  v) { return clamp(v, vec2(0.0), vec2(1.0)); }
vec3  saturate(vec3  v) { return clamp(v, vec3(0.0), vec3(1.0)); }
vec4  saturate(vec4  v) { return clamp(v, vec4(0.0), vec4(1.0)); }


float remap(float In, vec2 InMinMax, vec2 OutMinMax) { 
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}
vec2  remap(vec2 In, vec2 InMinMax, vec2 OutMinMax) {
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}
vec3  remap(vec3 In, vec2 InMinMax, vec2 OutMinMax) {
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}
vec4  remap(vec4 In, vec2 InMinMax, vec2 OutMinMax) {
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}


vec3 ToLinear(vec3 color)
{
    return pow(color, vec3(2.20f));
}

vec3 ToGamma(vec3 color)
{
    return pow(color, vec3(1.0 / 2.20f));
}

float rand12(vec2 p2)
{
    return fract(sin(dot(p2, vec2(12.9898, 78.233))) * 43758.5453);
}

float rand13(vec3 p3)
{
    p3 = fract(p3 * .1031);
    p3 += dot(p3, p3.zyx + 31.32);
    return fract((p3.x + p3.y) * p3.z);
}

float fresnelEffect(vec3 normal, vec3 viewDir, float power)
{
    return pow((1.0 - saturate(dot(normal, normalize(viewDir)))), power);
}

vec2 polarCoordUV(vec2 UV, vec2 Center, float RadialScale, float LengthScale)
{
    vec2 delta = UV - Center;
    float radius = length(delta) * 2.0 * RadialScale;
    float angle = atan(delta.y, delta.x) * 1.0 / 6.28 * LengthScale;
    return vec2(radius, angle);
}

vec2 radialShearUV(vec2 UV, vec2 Center, float Strength, vec2 Offset)
{
    vec2 delta = UV - Center;
    float delta2 = dot(delta.xy, delta.xy);
    vec2 delta_offset = delta2.xx * Strength;
    return UV + vec2(delta.y, -delta.x) * delta_offset + Offset;
}

vec2 rotateUV(vec2 UV, vec2 Center, float Rotation)
{
    UV -= Center;
    float s = sin(Rotation);
    float c = cos(Rotation);
    mat2 rMatrix = mat2(c, s, -s, c);
    rMatrix *= 0.5;
    rMatrix += 0.5;
    rMatrix = rMatrix * 2 - 1;
    UV.xy = rMatrix * UV.xy;
    UV += Center;
    return UV;
}

vec2 spherizeUV(vec2 UV, vec2 Center, float Strength, vec2 Offset)
{
    vec2 delta = UV - Center;
    float delta2 = dot(delta.xy, delta.xy);
    float delta4 = delta2 * delta2;
    vec2 delta_offset = delta4.xx * Strength;
    return UV + delta * delta_offset + Offset;
}

float colorMaskFloat(vec3 In, vec3 MaskColor, float Range, float Fuzziness)
{
    float Distance = distance(MaskColor, In);
    return saturate(1 - (Distance - Range) / max(Fuzziness, 1e-5));
}

// BLENDING =======================================================

vec3 contrastFloat(vec3 In, float Contrast)
{
    float midpoint = pow(0.5, 2.2);
    return (In - midpoint) * Contrast + midpoint;
}

vec3 hueFloat(vec3 In, float Offset)
{
    vec4 K = vec4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    vec4 P = mix(vec4(In.bg, K.wz), vec4(In.gb, K.xy), step(In.b, In.g));
    vec4 Q = mix(vec4(P.xyw, In.r), vec4(In.r, P.yzx), step(P.x, In.r));
    float D = Q.x - min(Q.w, Q.y);
    float E = 1e-10;
    vec3 hsv = vec3(abs(Q.z + (Q.w - Q.y) / (6.0 * D + E)), D / (Q.x + E), Q.x);

    float hue = hsv.x + Offset;
    hsv.x = (hue < 0) ? hue + 1 : (hue > 1) ? hue - 1 : hue;

    vec4 K2 = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 P2 = abs(fract(hsv.xxx + K2.xyz) * 6.0 - K2.www);
    return hsv.z * mix(K2.xxx, saturate(P2 - K2.xxx), hsv.y);
}

vec3 saturationFloat(vec3 In, float Saturation)
{
    float luma = dot(In, vec3(0.2126729, 0.7151522, 0.0721750));
    return luma.xxx + Saturation.xxx * (In - luma.xxx);
}

vec3 whiteBalanceFloat(vec3 In, float Temperature, float Tint)
{
    // Range ~[-1.67;1.67] works best
    float t1 = Temperature * 10 / 6;
    float t2 = Tint * 10 / 6;

    // Get the CIE xy chromaticity of the reference white point.
    // Note: 0.31271 = x value on the D65 white point
    float x = 0.31271 - t1 * (t1 < 0 ? 0.1 : 0.05);
    float standardIlluminantY = 2.87 * x - 3 * x * x - 0.27509507;
    float y = standardIlluminantY + t2 * 0.05;

    // Calculate the coefficients in the LMS space.
    vec3 w1 = vec3(0.949237, 1.03542, 1.08728); // D65 white point

    // CIExyToLMS
    float Y = 1;
    float X = Y * x / y;
    float Z = Y * (1 - x - y) / y;
    float L = 0.7328 * X + 0.4296 * Y - 0.1624 * Z;
    float M = -0.7036 * X + 1.6975 * Y + 0.0061 * Z;
    float S = 0.0030 * X + 0.0136 * Y + 0.9834 * Z;
    vec3 w2 = vec3(L, M, S);

    vec3 balance = vec3(w1.x / w2.x, w1.y / w2.y, w1.z / w2.z);

    mat3 LIN_2_LMS_MAT = mat3(
        3.90405e-1, 7.08416e-2, 2.31082e-2, 
        5.49941e-1, 9.63172e-1, 1.28021e-1, 
        8.92632e-3, 1.35775e-3, 9.36245e-1
    );

    mat3 LMS_2_LIN_MAT = mat3(
        2.85847e+0, -2.10182e-1, -4.18120e-2, 
        -1.62879e+0, 1.15820e+0, -1.18169e-1,
        -2.48910e-2, 3.24281e-4, 1.06867e+0
    );

    vec3 lms = LIN_2_LMS_MAT * In;
    lms *= balance;
    return LMS_2_LIN_MAT * lms;
}

vec3 Burn(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = 1.0 - (1.0 - Blend) / Base;
    return mix(Base, Out, Opacity);
}

vec3 Darken(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = min(Blend, Base);
    return mix(Base, Out, Opacity);
}

vec3 Difference(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = abs(Blend - Base);
    return mix(Base, Out, Opacity);
}

vec3 Dodge(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base / (1.0 - Blend);
    return mix(Base, Out, Opacity);
}

vec3 Divide(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base / (Blend + 0.000000000001);
    return mix(Base, Out, Opacity);
}

vec3 Exclusion(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Blend + Base - (2.0 * Blend * Base);
    return mix(Base, Out, Opacity);
}

vec3 HardLight(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
    vec3 result2 = 2.0 * Base * Blend;
    vec3 zeroOrOne = step(Blend, vec3(0.5, 0.5, 0.5));
    vec3 Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    return mix(Base, Out, Opacity);
}

vec3 HardMix(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = step(1 - Base, Blend);
    return mix(Base, Out, Opacity);
}

vec3 Lighten(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = max(Blend, Base);
    return mix(Base, Out, Opacity);
}

vec3 LinearBurn(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base + Blend - 1.0;
    return mix(Base, Out, Opacity);
}

vec3 LinearDodge(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base + Blend;
    return mix(Base, Out, Opacity);
}

vec3 LinearLight(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = vec3(1.0);
    Out.r = Blend.r < 0.5 ? max(Base.r + (2 * Blend.r) - 1, 0) : min(Base.r + 2 * (Blend.r - 0.5), 1);
    Out.g = Blend.g < 0.5 ? max(Base.g + (2 * Blend.g) - 1, 0) : min(Base.g + 2 * (Blend.g - 0.5), 1);
    Out.b = Blend.b < 0.5 ? max(Base.b + (2 * Blend.b) - 1, 0) : min(Base.b + 2 * (Blend.b - 0.5), 1);
    return mix(Base, Out, Opacity);
}

vec3 LinearLightAddSub(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Blend + 2.0 * Base - 1.0;
    return mix(Base, Out, Opacity);
}

vec3 Multiply(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base * Blend;
    return mix(Base, Out, Opacity);
}

vec3 Negation(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = 1.0 - abs(1.0 - Blend - Base);
    return mix(Base, Out, Opacity);
}

vec3 Overlay(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
    vec3 result2 = 2.0 * Base * Blend;
    vec3 zeroOrOne = step(Base, vec3(0.5, 0.5, 0.5));
    vec3 Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    return mix(Base, Out, Opacity);
}

vec3 PinLight(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 check = step(vec3(0.5, 0.5, 0.5), Blend);
    vec3 result1 = check * max(2.0 * (Base - 0.5), Blend);
    vec3 Out = result1 + (1.0 - check) * min(2.0 * Base, Blend);
    return mix(Base, Out, Opacity);
}

vec3 Screen(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = 1.0 - (1.0 - Blend) * (1.0 - Base);
    return mix(Base, Out, Opacity);
}

vec3 SoftLight(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 result1 = 2.0 * Base * Blend + Base * Base * (1.0 - 2.0 * Blend);
    vec3 result2 = sqrt(Base) * (2.0 * Blend - 1.0) + 2.0 * Base * (1.0 - Blend);
    vec3 zeroOrOne = step(vec3(0.5, 0.5, 0.5), Blend);
    vec3 Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    return mix(Base, Out, Opacity);
}

vec3 Subtract(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 Out = Base - Blend;
    return mix(Base, Out, Opacity);
}

vec3 VividLight(vec3 Base, vec3 Blend, float Opacity)
{
    vec3 result1 = 1.0 - (1.0 - Blend) / (2.0 * Base);
    vec3 result2 = Blend / (2.0 * (1.0 - Base));
    vec3 zeroOrOne = step(vec3(0.5, 0.5, 0.5), Base);
    vec3 Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    return mix(Base, Out, Opacity);
}

vec3 Overwrite(vec3 Base, vec3 Blend, float Opacity)
{
    return mix(Base, Blend, Opacity);
}

// Noise ==========================================================

float noise_interpolate(float a, float b, float t)
{
    return (1.0 - t) * a + (t * b);
}

float valueNoise(vec2 uv)
{
    vec2 i = floor(uv);
    vec2 f = fract(uv);
    f = f * f * (3.0 - 2.0 * f);

    uv = abs(fract(uv) - 0.5);
    vec2 c0 = i + vec2(0.0, 0.0);
    vec2 c1 = i + vec2(1.0, 0.0);
    vec2 c2 = i + vec2(0.0, 1.0);
    vec2 c3 = i + vec2(1.0, 1.0);
    float r0 = rand12(c0);
    float r1 = rand12(c1);
    float r2 = rand12(c2);
    float r3 = rand12(c3);

    float bottomOfGrid = noise_interpolate(r0, r1, f.x);
    float topOfGrid = noise_interpolate(r2, r3, f.x);
    float t = noise_interpolate(bottomOfGrid, topOfGrid, f.y);
    return t;
}

float simpleNoise2D(vec2 uv, float scale)
{
    float t = 0.0;
    float freq = pow(2.0, float(0));
    float amp = pow(0.5, float(3 - 0));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    freq = pow(2.0, float(1));
    amp = pow(0.5, float(3 - 1));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    freq = pow(2.0, float(2));
    amp = pow(0.5, float(3 - 2));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    return t;
}

vec2 voronoi_noise_randomVector(vec2 UV, float offset)
{
    mat2 m = mat2(15.27, 99.41, 47.63, 89.98);
    UV = fract(sin(m * UV) * 46839.32);
    return vec2(sin(UV.y * +offset) * 0.5 + 0.5, cos(UV.x * offset) * 0.5 + 0.5);
}

void voronoiFloat(vec2 UV, float angleOffset, float cellDensity, out float Out, out float Cells)
{
    vec2 g = floor(UV * cellDensity);
    vec2 f = fract(UV * cellDensity);
    float t = 8.0;
    vec3 res = vec3(8.0, 0.0, 0.0);

    for (int y = -1; y <= 1; y++)
    {
        for (int x = -1; x <= 1; x++)
        {
            vec2 lattice = vec2(x, y);
            vec2 offset = voronoi_noise_randomVector(lattice + g, angleOffset);
            float d = distance(lattice + offset, f);
            if (d < res.x)
            {
                res = vec3(d, offset.x, offset.y);
                Out = res.x;
                Cells = res.y;
            }
        }
    }
}