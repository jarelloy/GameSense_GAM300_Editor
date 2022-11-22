using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

[StructLayout(LayoutKind.Sequential)]
public struct ColorGrading
{
    public int enabled;
    public float temperature;
    public float temperatureFactor;
    public float tint;
    public float tintFactor;
    public Vector3 PADDING;
    public Vector4 colorFilter;
    public float hueShift;
    public float saturation;
    public float brightness;
    public float contrast;
}

[StructLayout(LayoutKind.Sequential)]
public struct Bloom
{
    public int enabled;
    public float intensity;
    public float threshold;
    public float softknee;
    public float clamp;
    public float diffusion;
    public float anamorphicRatio;
    public float blurScale;
    public float blurStrength;
    public Vector3 PADDING;
    public Vector3 color;
}

[StructLayout(LayoutKind.Sequential)]
public struct Vignette
{
    public int enabled;
    public Vector3 PADDING;
    public Vector4 color;
    public Vector2 center;
    public float intensity;
    public float smoothness;
    public float roundness;
    public int rounded;
}

public static class Graphics
{
    public static float ambientIntensity
    {
        get
        {
            return InternalCalls.Graphics_GetAmbientIntensity();
        }
        set
        {
            InternalCalls.Graphics_SetAmbientIntensity(value);
        }
    }

    public static Vector3 ambientColor
    {
        get
        {
            InternalCalls.Graphics_GetAmbientColor(out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Graphics_SetAmbientColor(ref value);
        }
    }

    public static float gamma
    {
        get
        {
            return InternalCalls.Graphics_GetGamma();
        }
        set
        {
            InternalCalls.Graphics_SetGamma(value);
        }
    }

    public static float exposure
    {
        get
        {
            return InternalCalls.Graphics_GetExposure();
        }
        set
        {
            InternalCalls.Graphics_SetExposure(value);
        }
    }
}

public static class PostProcessing
{
    public static int enabled
    {
        get
        {
            return InternalCalls.PostProcessing_GetEnabled();
        }
        set
        {
            InternalCalls.PostProcessing_SetEnabled(value);
        }
    }

    public static ColorGrading colorGrading
    {
        get
        {
            InternalCalls.PostProcessing_GetColorGrading(out ColorGrading result);
            return result; 
        }
        set
        {
            InternalCalls.PostProcessing_SetColorGrading(ref value);
        }
    }

    public static Bloom bloom
    {
        get
        {
            InternalCalls.PostProcessing_GetBloom(out Bloom result);
            return result; 
        }
        set
        {
            InternalCalls.PostProcessing_SetBloom(ref value);
        }
    }

    public static Vignette vignette
    {
        get
        {
            InternalCalls.PostProcessing_GetVignette(out Vignette result);
            return result; 
        }
        set
        {
            InternalCalls.PostProcessing_SetVignette(ref value);
        }
    }
}
