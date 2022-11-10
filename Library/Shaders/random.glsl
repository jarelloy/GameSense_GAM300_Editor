#include "simplex_noise.glsl"

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