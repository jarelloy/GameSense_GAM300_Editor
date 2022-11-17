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
    public Vector2(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
    }

    public static Vector2 operator +(Vector2 rhs) => rhs;

    public static Vector2 operator -(Vector2 rhs) => new Vector2(-rhs.x, -rhs.y);

    public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        => new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);

    public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        => new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2 operator *(Vector2 lhs, float value)
        => new Vector2(lhs.x * value, lhs.y * value);

    public static Vector2 operator *(float value, Vector2 lhs)
        => new Vector2(lhs.x * value, lhs.y * value);

    public static Vector2 operator /(Vector2 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector2(lhs.x / value, lhs.y / value);
    }

    public override string ToString() => $"({x}, {y})";

    public static Vector2 Lerp(Vector2 startVec, Vector2 endVec, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);

        float xValue = startVec.x + (endVec.x - startVec.x) * timer;
        float yValue = startVec.y + (endVec.y - startVec.y) * timer;

        return new Vector2(xValue, yValue);
    }

    // shorthand functions
    public static Vector2 down
    {
        get
        {
            return new Vector2(0, -1);
        }
    }

    public static Vector2 left
    {
        get
        {
            return new Vector2(-1, 0);
        }
    }

    public static Vector2 one
    {
        get
        {
            return new Vector2(1, 1);
        }
    }

    public static Vector2 right
    {
        get
        {
            return new Vector2(1, 0);
        }
    }

    public static Vector2 up
    {
        get
        {
            return new Vector2(0, 1);
        }
    }

    public static Vector2 zero
    {
        get
        {
            return new Vector2(0, 0);
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Vector2Int
{
    public int x;
    public int y;
    public Vector2Int(int x1, int y1)
    {
        x = x1;
        y = y1;
    }
    public Vector2Int(Vector2Int v2)
    {
        x = v2.x;
        y = v2.y;
    }

    public static Vector2Int operator +(Vector2Int rhs) => rhs;

    public static Vector2Int operator -(Vector2Int rhs) => new Vector2Int(-rhs.x, -rhs.y);

    public static Vector2Int operator +(Vector2Int lhs, Vector2Int rhs)
        => new Vector2Int(lhs.x + rhs.x, lhs.y + rhs.y);

    public static Vector2Int operator -(Vector2Int lhs, Vector2Int rhs)
        => new Vector2Int(lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2Int operator *(Vector2Int lhs, int value)
        => new Vector2Int(lhs.x * value, lhs.y * value);

    public static Vector2Int operator *(int value, Vector2Int lhs)
        => new Vector2Int(lhs.x * value, lhs.y * value);

    public static Vector2Int operator /(Vector2Int lhs, int value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector2Int(lhs.x / value, lhs.y / value);
    }

    public override string ToString() => $"({x}, {y})";
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
    public Vector3(Vector3Int v3i)
    {
        x = v3i.x;
        y = v3i.y;
        z = v3i.z;
    }

    public static Vector3 operator +(Vector3 rhs) => rhs;

    public static Vector3 operator -(Vector3 rhs) => new Vector3(-rhs.x, -rhs.y, -rhs.z);

    public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        => new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

    public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        => new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

    public static Vector3 operator *(Vector3 lhs, float value)
        => new Vector3(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3 operator *(float value, Vector3 lhs)
        => new Vector3(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3 operator /(Vector3 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector3(lhs.x / value, lhs.y / value, lhs.z / value);
    }

    public override string ToString() => $"({x}, {y}, {z})";

    public static Vector3 Lerp(Vector3 startVec, Vector3 endVec, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);

        float xValue = startVec.x + (endVec.x - startVec.x) * timer;
        float yValue = startVec.y + (endVec.y - startVec.y) * timer;
        float zValue = startVec.z + (endVec.z - startVec.z) * timer;

        return new Vector3(xValue, yValue, zValue);
    }


}

[StructLayout(LayoutKind.Sequential)]
public struct Vector3Int
{
    public int x;
    public int y;
    public int z;

    public Vector3Int(int x1, int y1, int z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }
    public Vector3Int(Vector3Int v2)
    {
        x = v2.x;
        y = v2.y;
        z = v2.z;
    }
    public Vector3Int(Vector3 v3)
    {
        x = (int)v3.x;
        y = (int)v3.y;
        z = (int)v3.z;
    }

    public static Vector3Int operator +(Vector3Int rhs) => rhs;

    public static Vector3Int operator -(Vector3Int rhs) => new Vector3Int(-rhs.x, -rhs.y, -rhs.z);

    public static Vector3Int operator +(Vector3Int lhs, Vector3Int rhs)
        => new Vector3Int(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

    public static Vector3Int operator -(Vector3Int lhs, Vector3Int rhs)
        => new Vector3Int(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

    public static Vector3Int operator *(Vector3Int lhs, int value)
        => new Vector3Int(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3Int operator *(int value, Vector3Int lhs)
        => new Vector3Int(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3Int operator /(Vector3Int lhs, int value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector3Int(lhs.x / value, lhs.y / value, lhs.z / value);
    }

    public override string ToString() => $"({x}, {y}, {z})";
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

    public static Vector4 operator +(Vector4 rhs) => rhs;

    public static Vector4 operator -(Vector4 rhs) => new Vector4(-rhs.x, -rhs.y, -rhs.z, -rhs.w);

    public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        => new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

    public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        => new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

    public static Vector4 operator *(Vector4 lhs, float value)
        => new Vector4(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4 operator *(float value, Vector4 lhs)
        => new Vector4(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4 operator /(Vector4 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector4(lhs.x / value, lhs.y / value, lhs.z / value, lhs.w * value);
    }

    public override string ToString() => $"({x}, {y}, {z} , {w})";
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
