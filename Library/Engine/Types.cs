using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


[StructLayout(LayoutKind.Sequential)]
public struct ComponentBase
{
    public bool isDirty;

    public ComponentBase(bool dirty = true)
    {
        isDirty = dirty;
    }
}
[StructLayout(LayoutKind.Sequential)]
public struct Vector2
{
    public float x;
    public float y;
    public Vector2(float x1, float y1)
    {
        x = x1;
        y = y1;
    }
    public Vector2(Vector2 v2)
    {
        x = v2.x;
        y = v2.y;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Vector3
{
    public float x;
    public float y;
    public float z;

    public Vector3(float x1, float y1, float z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }
    public Vector3(Vector3 v2)
    {
        x = v2.x;
        y = v2.y;
        z = v2.z;
    }

}

[StructLayout(LayoutKind.Sequential)]
public struct Vector4
{
    public float x;
    public float y;
    public float z;
    public float w;

    public float r 
    { 
        get 
        {
            return x;
        }
        set
        {
            x = value;
        } 
    }
    public float g
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }
    public float b
    {
        get
        {
            return z;
        }
        set
        {
            z = value;
        }
    }
    public float a
    {
        get
        {
            return w;
        }
        set
        {
            w = value;
        }
    }

    public Vector4(float x1, float y1, float z1, float w1)
    {
        x = x1;
        y = y1;
        z = z1;
        w = w1;
    }
    public Vector4(Vector4 v2)
    {
        x = v2.x;
        y = v2.y;
        z = v2.z;
        w = v2.w;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Matrix4
{
    public float m00; public float m01; public float m02; public float m03; //1st Column
    public float m10; public float m11; public float m12; public float m13; //2nd Column
    public float m20; public float m21; public float m22; public float m23; //3rd Column
    public float m30; public float m31; public float m32; public float m33; //4th Column
}

public enum LeftAlignment
{
    LEFT,
	CENTER,
	RIGHT
};

public enum SOUND_GROUP
{
    SFX = 0,
	MUSIC = 1,
    STEREO = 2,
    MASTER = 3
};
    
public enum EQ_GROUP
{
    NORMAL = 0,
    LOW_PASS_FILTER = 1,
    ECHO = 2,
    DISTORTION = 3
};
