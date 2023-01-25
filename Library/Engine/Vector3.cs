using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Vector3
[StructLayout(LayoutKind.Sequential)]
public struct Vector3
{
    #region Fields
    public float x;
    public float y;
    public float z;
    #endregion

    #region Constructors
    public Vector3(float x1, float y1, float z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }
    public Vector3(float v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
    }
    public Vector3(Vector2 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = 0f;
    }
    public Vector3(Vector2 v, float z)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
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
    public Vector3(Vector4 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Vector2Int(Vector3 v) => new Vector2Int((int)v.x, (int)v.y);

    public static explicit operator Vector3Int(Vector3 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

    public static explicit operator Vector4Int(Vector3 v) => new Vector4Int((int)v.x, (int)v.y, (int)v.z, 0);

    public static explicit operator Vector2(Vector3 v) => new Vector2((float)v.x, (float)v.y);

    public static explicit operator Vector4(Vector3 v) => new Vector4((float)v.x, (float)v.y, (float)v.z, 0f);
    #endregion

    #region Index
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x;
                case 1: return y;
                case 2: return z;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x = value; break;
                case 1: y = value; break;
                case 2: z = value; break;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
    }
    #endregion

    #region Properties
    public Vector2 xy
    {
        get
        {
            return new Vector2(x, y);
        }
        set
        {
            x = value.x;
            y = value.y;
        }
    }

    public Vector2 xz
    {
        get
        {
            return new Vector2(x, z);
        }
        set
        {
            x = value.x;
            z = value.y;
        }
    }

    public Vector2 yz
    {
        get
        {
            return new Vector2(y, z);
        }
        set
        {
            y = value.x;
            z = value.y;
        }
    }

    public Vector3 xyz
    {
        get
        {
            return new Vector3(x, y, z);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
    }

    public Vector2 rg
    {
        get
        {
            return new Vector2(x, y);
        }
        set
        {
            x = value.x;
            y = value.y;
        }
    }

    public Vector2 rb
    {
        get
        {
            return new Vector2(x, z);
        }
        set
        {
            x = value.x;
            z = value.y;
        }
    }

    public Vector2 gb
    {
        get
        {
            return new Vector2(y, z);
        }
        set
        {
            y = value.x;
            z = value.y;
        }
    }

    public Vector3 rgb
    {
        get
        {
            return new Vector3(x, y, z);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
    }

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

    public int Count => 3;

    public float MinElement => Math.Min(Math.Min(x, y), z);

    public float MaxElement => Math.Max(Math.Max(x, y), z);

    public float Length => (float)Math.Sqrt(((x * x + y * y) + z * z));

    public float LengthSqr => ((x * x + y * y) + z * z);

    public float Sum => ((x + y) + z);

    public Vector3 Normalized => this / (float)Length;

    public Vector3 NormalizedSafe => this == Zero ? Zero : this / (float)Length;
    #endregion

    #region Static Vectors
    public static Vector3 Zero { get; } = new Vector3(0f, 0f, 0f);

    public static Vector3 One { get; } = new Vector3(1f, 1f, 1f);

    public static Vector3 Left { get; } = new Vector3(-1f, 0f, 0f);

    public static Vector3 Right { get; } = new Vector3(1f, 0f, 0f);

    public static Vector3 Up { get; } = new Vector3(0f, 1f, 0f);

    public static Vector3 Down { get; } = new Vector3(0f, -1f, 0f);

    public static Vector3 Forward { get; } = new Vector3(0f, 0f, -1f);

    public static Vector3 Back { get; } = new Vector3(0f, 0f, 1f);

    public static Vector3 MaxValue { get; } = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

    public static Vector3 MinValue { get; } = new Vector3(float.MinValue, float.MinValue, float.MinValue);

    public static Vector3 Epsilon { get; } = new Vector3(float.Epsilon, float.Epsilon, float.Epsilon);

    public static Vector3 NaN { get; } = new Vector3(float.NaN, float.NaN, float.NaN);

    public static Vector3 NegativeInfinity { get; } = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

    public static Vector3 PositiveInfinity { get; } = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
    #endregion

    #region Operators

    public static bool operator ==(Vector3 lhs, Vector3 rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector3 lhs, Vector3 rhs) => !lhs.Equals(rhs);

    public static Vector3 operator +(Vector3 rhs) => rhs;

    public static Vector3 operator -(Vector3 rhs) => new Vector3(-rhs.x, -rhs.y, -rhs.z);

    public static Vector3 operator +(Vector3 lhs, Vector3 rhs) => new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

    public static Vector3 operator -(Vector3 lhs, Vector3 rhs) => new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

    public static Vector3 operator *(Vector3 lhs, float value) => new Vector3(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3 operator *(float value, Vector3 lhs) => new Vector3(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3 operator / (Vector3 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector3(lhs.x / value, lhs.y / value, lhs.z / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y}, {z})";

    public bool Equals(Vector3 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector3 && Equals((Vector3)obj);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode();
        }
    }

    public static float Dot(Vector3 lhs, Vector3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);

    public static float Distance(Vector3 lhs, Vector3 rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector3 lhs, Vector3 rhs) => (lhs - rhs).LengthSqr;

    public static Vector3 Cross(Vector3 l, Vector3 r) => new Vector3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);

    public static Vector3 Reflect(Vector3 I, Vector3 N) => I - 2 * Dot(N, I) * N;

    public static Vector3 Abs(Vector3 v) => new Vector3(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));

    public static Vector3 Max(Vector3 lhs, Vector3 rhs) => new Vector3(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));

    public static Vector3 Min(Vector3 lhs, Vector3 rhs) => new Vector3(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));

    public static Vector3 Clamp(Vector3 v, Vector3 min, Vector3 max) => new Vector3(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z));

    public static Vector3 Clamp(Vector3 v, float min, float max) => new Vector3(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max));

    public static Vector3 Degrees(Vector3 v) => new Vector3((float)(v.x * 57.295779513082320876798154814105170332405472466564321f), (float)(v.y * 57.295779513082320876798154814105170332405472466564321f), (float)(v.z * 57.295779513082320876798154814105170332405472466564321f));

    public static Vector3 Degrees(float v) => new Vector3((float)(v * 57.295779513082320876798154814105170332405472466564321f));

    public static Vector3 Radians(Vector3 v) => new Vector3((float)(v.x * 0.0174532925199432957692369076848861271344287188854172f), (float)(v.y * 0.0174532925199432957692369076848861271344287188854172f), (float)(v.z * 0.0174532925199432957692369076848861271344287188854172f));

    public static Vector3 Radians(float v) => new Vector3((float)(v * 0.0174532925199432957692369076848861271344287188854172f));

    public static Vector3 Acos(Vector3 v) => new Vector3((float)Math.Acos((double)v.x), (float)Math.Acos((double)v.y), (float)Math.Acos((double)v.z));

    public static Vector3 Acos(float v) => new Vector3((float)Math.Acos((double)v));

    public static Vector3 Asin(Vector3 v) => new Vector3((float)Math.Asin((double)v.x), (float)Math.Asin((double)v.y), (float)Math.Asin((double)v.z));

    public static Vector3 Asin(float v) => new Vector3((float)Math.Asin((double)v));

    public static Vector3 Atan(Vector3 v) => new Vector3((float)Math.Atan((double)v.x), (float)Math.Atan((double)v.y), (float)Math.Atan((double)v.z));

    public static Vector3 Atan(float v) => new Vector3((float)Math.Atan((double)v));

    public static Vector3 Cos(Vector3 v) => new Vector3((float)Math.Cos((double)v.x), (float)Math.Cos((double)v.y), (float)Math.Cos((double)v.z));

    public static Vector3 Cos(float v) => new Vector3((float)Math.Cos((double)v));

    public static Vector3 Cosh(Vector3 v) => new Vector3((float)Math.Cosh((double)v.x), (float)Math.Cosh((double)v.y), (float)Math.Cosh((double)v.z));

    public static Vector3 Cosh(float v) => new Vector3((float)Math.Cosh((double)v));

    public static Vector3 Sin(Vector3 v) => new Vector3((float)Math.Sin((double)v.x), (float)Math.Sin((double)v.y), (float)Math.Sin((double)v.z));

    public static Vector3 Sin(float v) => new Vector3((float)Math.Sin((double)v));

    public static Vector3 Sinh(Vector3 v) => new Vector3((float)Math.Sinh((double)v.x), (float)Math.Sinh((double)v.y), (float)Math.Sinh((double)v.z));

    public static Vector3 Sinh(float v) => new Vector3((float)Math.Sinh((double)v));

    public static Vector3 Tan(Vector3 v) => new Vector3((float)Math.Tan((double)v.x), (float)Math.Tan((double)v.y), (float)Math.Tan((double)v.z));

    public static Vector3 Tan(float v) => new Vector3((float)Math.Tan((double)v));

    public static Vector3 Tanh(Vector3 v) => new Vector3((float)Math.Tanh((double)v.x), (float)Math.Tanh((double)v.y), (float)Math.Tanh((double)v.z));

    public static Vector3 Tanh(float v) => new Vector3((float)Math.Tanh((double)v));

    public static Vector3 Lerp(Vector3 startVec, Vector3 endVec, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);

        float xValue = startVec.x + (endVec.x - startVec.x) * timer;
        float yValue = startVec.y + (endVec.y - startVec.y) * timer;
        float zValue = startVec.z + (endVec.z - startVec.z) * timer;

        return new Vector3(xValue, yValue, zValue);
    }

    #endregion
}
#endregion

#region Vector3Int
[StructLayout(LayoutKind.Sequential)]
public struct Vector3Int
{
    #region Fields
    public int x;
    public int y;
    public int z;
    #endregion

    #region Constructors
    public Vector3Int(int x1, int y1, int z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }
    public Vector3Int(int v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
    }
    public Vector3Int(Vector2Int v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = 0;
    }
    public Vector3Int(Vector2Int v, int z)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
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
    public Vector3Int(Vector4Int v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    #endregion

    #region Conversion Operators
    public static implicit operator Vector3(Vector3Int v) => new Vector3((float)v.x, (float)v.y, (float)v.z);

    public static explicit operator Vector2Int(Vector3Int v) => new Vector2Int((int)v.x, (int)v.y);

    public static explicit operator Vector4Int(Vector3Int v) => new Vector4Int((int)v.x, (int)v.y, (int)v.z, 0);

    public static explicit operator Vector2(Vector3Int v) => new Vector2((float)v.x, (float)v.y);

    public static explicit operator Vector4(Vector3Int v) => new Vector4((float)v.x, (float)v.y, (float)v.z, 0f);
    #endregion

    #region Index
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x;
                case 1: return y;
                case 2: return z;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x = value; break;
                case 1: y = value; break;
                case 2: z = value; break;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
    }
    #endregion

    #region Properties
    public Vector2Int xy
    {
        get
        {
            return new Vector2Int(x, y);
        }
        set
        {
            x = value.x;
            y = value.y;
        }
    }

    public Vector2Int xz
    {
        get
        {
            return new Vector2Int(x, z);
        }
        set
        {
            x = value.x;
            z = value.y;
        }
    }

    public Vector2Int yz
    {
        get
        {
            return new Vector2Int(y, z);
        }
        set
        {
            y = value.x;
            z = value.y;
        }
    }

    public Vector3Int xyz
    {
        get
        {
            return new Vector3Int(x, y, z);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
    }

    public Vector2Int rg
    {
        get
        {
            return new Vector2Int(x, y);
        }
        set
        {
            x = value.x;
            y = value.y;
        }
    }

    public Vector2Int rb
    {
        get
        {
            return new Vector2Int(x, z);
        }
        set
        {
            x = value.x;
            z = value.y;
        }
    }

    public Vector2Int gb
    {
        get
        {
            return new Vector2Int(y, z);
        }
        set
        {
            y = value.x;
            z = value.y;
        }
    }

    public Vector3Int rgb
    {
        get
        {
            return new Vector3Int(x, y, z);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
    }

    public int r
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

    public int g
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

    public int b
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

    public int Count => 3;

    public int MinElement => Math.Min(Math.Min(x, y), z);

    public int MaxElement => Math.Max(Math.Max(x, y), z);

    public float Length => (float)Math.Sqrt(((x * x + y * y) + z * z));

    public float LengthSqr => ((x * x + y * y) + z * z);

    public int Sum => ((x + y) + z);
    #endregion

    #region Static Vectors
    public static Vector3Int Zero { get; } = new Vector3Int(0, 0, 0);

    public static Vector3Int One { get; } = new Vector3Int(1, 1, 1);

    public static Vector3Int Left { get; } = new Vector3Int(-1, 0, 0);

    public static Vector3Int Right { get; } = new Vector3Int(1, 0, 0);

    public static Vector3Int Up { get; } = new Vector3Int(0, 1, 0);

    public static Vector3Int Down { get; } = new Vector3Int(0, -1, 0);

    public static Vector3Int Forward { get; } = new Vector3Int(0, 0, -1);

    public static Vector3Int Back { get; } = new Vector3Int(0, 0, 1);

    public static Vector3Int MaxValue { get; } = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);

    public static Vector3Int MinValue { get; } = new Vector3Int(int.MinValue, int.MinValue, int.MinValue);
    #endregion

    #region Operators

    public static bool operator ==(Vector3Int lhs, Vector3Int rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector3Int lhs, Vector3Int rhs) => !lhs.Equals(rhs);

    public static Vector3Int operator +(Vector3Int rhs) => rhs;

    public static Vector3Int operator -(Vector3Int rhs) => new Vector3Int(-rhs.x, -rhs.y, -rhs.z);

    public static Vector3Int operator +(Vector3Int lhs, Vector3Int rhs) => new Vector3Int(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

    public static Vector3Int operator -(Vector3Int lhs, Vector3Int rhs) => new Vector3Int(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

    public static Vector3Int operator *(Vector3Int lhs, int value) => new Vector3Int(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3Int operator *(int value, Vector3Int lhs) => new Vector3Int(lhs.x * value, lhs.y * value, lhs.z * value);

    public static Vector3Int operator /(Vector3Int lhs, int value)
    {
        if (value.Equals(0))
        {
            throw new DivideByZeroException();
        }
        return new Vector3Int(lhs.x / value, lhs.y / value, lhs.z / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y}, {z})";

    public bool Equals(Vector3Int rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));
    
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector3Int && Equals((Vector3Int)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode();
        }
    }

    public static int Dot(Vector3Int lhs, Vector3Int rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);

    public static float Distance(Vector3Int lhs, Vector3Int rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector3Int lhs, Vector3Int rhs) => (lhs - rhs).LengthSqr;

    public static Vector3Int Cross(Vector3Int l, Vector3Int r) => new Vector3Int(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);

    public static Vector3Int Reflect(Vector3Int I, Vector3Int N) => I - 2 * Dot(N, I) * N;

    public static Vector3Int Abs(Vector3Int v) => new Vector3Int(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));

    public static Vector3Int Max(Vector3Int lhs, Vector3Int rhs) => new Vector3Int(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));

    public static Vector3Int Min(Vector3Int lhs, Vector3Int rhs) => new Vector3Int(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));

    public static Vector3Int Clamp(Vector3Int v, Vector3Int min, Vector3Int max) => new Vector3Int(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z));

    public static Vector3Int Clamp(Vector3Int v, int min, int max) => new Vector3Int(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max));
    #endregion
}
#endregion