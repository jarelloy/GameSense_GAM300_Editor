#include "simplex_noise.glsl"

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

vec2 rand23(vec3 p3)
{
    p3 = fract(p3 * vec3(.1031, .1030, .0973));
    p3 += dot(p3, p3.yzx + 33.33);
    return fract((p3.xx + p3.yz) * p3.zy);
}

vec3 rand33(vec3 p3)
{
    p3 = fract(p3 * vec3(.1031, .1030, .0973));
    p3 += dot(p3, p3.yxz + 33.33);
    return fract((p3.xxy + p3.yxx) * p3.zyx);
}

vec4 rand43(vec3 p)
{
    vec4 p4 = fract(vec4(p.xyzx) * vec4(.1031, .1030, .0973, .1099));
    p4 += dot(p4, p4.wzxy + 33.33);
    return fract((p4.xxyz + p4.yzzw) * p4.zywx);
}

vec3 randomPointOnSphere(float u, float v, float radius)
{
    float theta = 2 * PI * u;
    float phi = acos(2 * v - 1);
    float x = radius * sin(phi) * cos(theta);
    float y = radius * sin(phi) * sin(theta);
    float z = radius * cos(phi);
    return vec3(x, y, z);
}

vec3 curlNoise(vec3 coord)
{
    vec3 dx = vec3(EPSILON, 0.0, 0.0);
    vec3 dy = vec3(0.0, EPSILON, 0.0);
    vec3 dz = vec3(0.0, 0.0, EPSILON);

    vec3 dpdx0 = vec3(snoise(coord - dx));
    vec3 dpdx1 = vec3(snoise(coord + dx));
    vec3 dpdy0 = vec3(snoise(coord - dy));
    vec3 dpdy1 = vec3(snoise(coord + dy));
    vec3 dpdz0 = vec3(snoise(coord - dz));
    vec3 dpdz1 = vec3(snoise(coord + dz));

    float x = dpdy1.z - dpdy0.z + dpdz1.y - dpdz0.y;
    float y = dpdz1.x - dpdz0.x + dpdx1.z - dpdx0.z;
    float z = dpdx1.y - dpdx0.y + dpdy1.x - dpdy0.x;

    return vec3(x, y, z) / EPSILON * 2.0;
}

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
    float amp = pow(0.5, float(3-0));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    freq = pow(2.0, float(1));
    amp = pow(0.5, float(3 - 1));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    freq = pow(2.0, float(2));
    amp = pow(0.5, float(3 - 2));
    t += valueNoise(vec2(uv.x * scale / freq, uv.y * scale / freq)) * amp;

    return t;
}
