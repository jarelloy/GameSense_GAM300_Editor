using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Vector4
[StructLayout(LayoutKind.Sequential)]
public struct Vector4
{
    #region Fields
    public float x;
    public float y;
    public float z;
    public float w;
    #endregion

    #region Constructors
    public Vector4(float x1, float y1, float z1, float w1)
    {
        this.x = x1;
        this.y = y1;
        this.z = z1;
        this.w = w1;
    }
    public Vector4(float v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
        this.w = v;
    }
    public Vector4(Vector2 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = 0f;
        this.w = 0f;
    }
    public Vector4(Vector2 v, float z)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
        this.w = 0f;
    }
    public Vector4(Vector2 v, float z, float w)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
        this.w = w;
    }
    public Vector4(Vector3 v2)
    {
        this.x = v2.x;
        this.y = v2.y;
        this.z = v2.z;
        this.w = 0f;
    }
    public Vector4(Vector3 v2, float w)
    {
        this.x = v2.x;
        this.y = v2.y;
        this.z = v2.z;
        this.w = w;
    }

    public Vector4(Vector4 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.w = v.w;
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Vector2Int(Vector4 v) => new Vector2Int((int)v.x, (int)v.y);

    public static explicit operator Vector3Int(Vector4 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

    public static explicit operator Vector4Int(Vector4 v) => new Vector4Int((int)v.x, (int)v.y, (int)v.z, (int)v.w);

    public static explicit operator Vector2(Vector4 v) => new Vector2((float)v.x, (float)v.y);

    public static explicit operator Vector3(Vector4 v) => new Vector3((float)v.x, (float)v.y, (float)v.z);
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
                case 3: return w;
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
                case 3: w = value; break;
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

    public Vector2 xw
    {
        get
        {
            return new Vector2(x, w);
        }
        set
        {
            x = value.x;
            w = value.y;
        }
    }

    public Vector2 yw
    {
        get
        {
            return new Vector2(y, w);
        }
        set
        {
            y = value.x;
            w = value.y;
        }
    }

    public Vector3 xyw
    {
        get
        {
            return new Vector3(x, y, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            w = value.z;
        }
    }

    public Vector2 zw
    {
        get
        {
            return new Vector2(z, w);
        }
        set
        {
            z = value.x;
            w = value.y;
        }
    }

    public Vector3 xzw
    {
        get
        {
            return new Vector3(x, z, w);
        }
        set
        {
            x = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector3 yzw
    {
        get
        {
            return new Vector3(y, z, w);
        }
        set
        {
            y = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector4 xyzw
    {
        get
        {
            return new Vector4(x, y, z, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
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

    public Vector2 ra
    {
        get
        {
            return new Vector2(x, w);
        }
        set
        {
            x = value.x;
            w = value.y;
        }
    }

    public Vector2 ga
    {
        get
        {
            return new Vector2(y, w);
        }
        set
        {
            y = value.x;
            w = value.y;
        }
    }

    public Vector3 rga
    {
        get
        {
            return new Vector3(x, y, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            w = value.z;
        }
    }

    public Vector2 ba
    {
        get
        {
            return new Vector2(z, w);
        }
        set
        {
            z = value.x;
            w = value.y;
        }
    }

    public Vector3 rba
    {
        get
        {
            return new Vector3(x, z, w);
        }
        set
        {
            x = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector3 gba
    {
        get
        {
            return new Vector3(y, z, w);
        }
        set
        {
            y = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector4 rgba
    {
        get
        {
            return new Vector4(x, y, z, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
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

    public int Count => 4;

    public float MinElement => Math.Min(Math.Min(x, y), Math.Min(z, w));

    public float MaxElement => Math.Max(Math.Max(x, y), Math.Max(z, w));

    public float Length => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

    public float LengthSqr => ((x * x + y * y) + (z * z + w * w));

    public float Sum => ((x + y) + (z + w));

    public Vector4 Normalized => this / (float)Length;

    public Vector4 NormalizedSafe => this == Zero ? Zero : this / (float)Length;
    #endregion

    #region Static Vectors
    public static Vector4 Zero { get; } = new Vector4(0f, 0f, 0f, 0f);

    public static Vector4 Ones { get; } = new Vector4(1f, 1f, 1f, 1f);

    public static Vector4 Left { get; } = new Vector4(-1f, 0f, 0f, 0f);

    public static Vector4 Right { get; } = new Vector4(1f, 0f, 0, 0f);

    public static Vector4 Up { get; } = new Vector4(0f, 1f, 0f, 0f);

    public static Vector4 Down { get; } = new Vector4(0f, -1f, 0f, 0f);

    public static Vector4 Forward { get; } = new Vector4(0f, 0f, -1f, 0f);

    public static Vector4 Back { get; } = new Vector4(0f, 0f, 1f, 0f);

    public static Vector4 MaxValue { get; } = new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);

    public static Vector4 MinValue { get; } = new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);

    public static Vector4 Epsilon { get; } = new Vector4(float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon);

    public static Vector4 NaN { get; } = new Vector4(float.NaN, float.NaN, float.NaN, float.NaN);

    public static Vector4 NegativeInfinity { get; } = new Vector4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

    public static Vector4 PositiveInfinity { get; } = new Vector4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
    #endregion

    #region Operators

    public static bool operator ==(Vector4 lhs, Vector4 rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector4 lhs, Vector4 rhs) => !lhs.Equals(rhs);

    public static Vector4 operator +(Vector4 rhs) => rhs;

    public static Vector4 operator -(Vector4 rhs) => new Vector4(-rhs.x, -rhs.y, -rhs.z, -rhs.w);

    public static Vector4 operator +(Vector4 lhs, Vector4 rhs) => new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

    public static Vector4 operator -(Vector4 lhs, Vector4 rhs) => new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

    public static Vector4 operator *(Vector4 lhs, float value) => new Vector4(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4 operator *(float value, Vector4 lhs) => new Vector4(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4 operator / (Vector4 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector4(lhs.x / value, lhs.y / value, lhs.z / value, lhs.w / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y}, {z}, {w})";

    public bool Equals(Vector4 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z) && w.Equals(rhs.w));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector4 && Equals((Vector4)obj);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return ((((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode()) * 397) ^ w.GetHashCode();
        }
    }

    public static float Dot(Vector4 lhs, Vector4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

    public static float Distance(Vector4 lhs, Vector4 rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector4 lhs, Vector4 rhs) => (lhs - rhs).LengthSqr;

    public static Vector4 Reflect(Vector4 I, Vector4 N) => I - 2 * Dot(N, I) * N;

    public static Vector4 Abs(Vector4 v) => new Vector4(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z), Math.Abs(v.w));

    public static Vector4 Max(Vector4 lhs, Vector4 rhs) => new Vector4(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z), Math.Max(lhs.w, rhs.w));

    public static Vector4 Min(Vector4 lhs, Vector4 rhs) => new Vector4(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z), Math.Min(lhs.w, rhs.w));

    public static Vector4 Clamp(Vector4 v, Vector4 min, Vector4 max) => new Vector4(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z), Math.Min(Math.Max(v.w, min.w), max.w));

    public static Vector4 Clamp(Vector4 v, float min, float max) => new Vector4(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max), Math.Min(Math.Max(v.w, min), max));

    public static Vector4 Lerp(Vector4 startVec, Vector4 endVec, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);

        float xValue = startVec.x + (endVec.x - startVec.x) * timer;
        float yValue = startVec.y + (endVec.y - startVec.y) * timer;
        float zValue = startVec.z + (endVec.z - startVec.z) * timer;
        float wValue = startVec.w + (endVec.w - startVec.w) * timer;

        return new Vector4(xValue, yValue, zValue, wValue);
    }

    #endregion
}
#endregion

#region Vector4Int
[StructLayout(LayoutKind.Sequential)]
public struct Vector4Int
{
    #region Fields
    public int x;
    public int y;
    public int z;
    public int w;
    #endregion

    #region Constructors
    public Vector4Int(int x1, int y1, int z1, int w1)
    {
        this.x = x1;
        this.y = y1;
        this.z = z1;
        this.w = w1;
    }
    public Vector4Int(int v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
        this.w = v;
    }
    public Vector4Int(Vector2Int v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = 0;
        this.w = 0;
    }
    public Vector4Int(Vector2Int v, int z)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
        this.w = 0;
    }
    public Vector4Int(Vector2Int v, int z, int w)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = z;
        this.w = w;
    }
    public Vector4Int(Vector3Int v2)
    {
        this.x = v2.x;
        this.y = v2.y;
        this.z = v2.z;
        this.w = 0;
    }
    public Vector4Int(Vector3Int v2, int w)
    {
        this.x = v2.x;
        this.y = v2.y;
        this.z = v2.z;
        this.w = w;
    }

    public Vector4Int(Vector4Int v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.w = v.w;
    }
    #endregion

    #region Conversion Operators
    public static implicit operator Vector4(Vector4Int v) => new Vector4((float)v.x, (float)v.y, (float)v.z, (float)v.w);

    public static explicit operator Vector2Int(Vector4Int v) => new Vector2Int((int)v.x, (int)v.y);

    public static explicit operator Vector3Int(Vector4Int v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

    public static explicit operator Vector2(Vector4Int v) => new Vector2((float)v.x, (float)v.y);

    public static explicit operator Vector3(Vector4Int v) => new Vector3((float)v.x, (float)v.y, (float)v.z);
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
                case 3: return w;
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
                case 3: w = value; break;
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

    public Vector2Int xw
    {
        get
        {
            return new Vector2Int(x, w);
        }
        set
        {
            x = value.x;
            w = value.y;
        }
    }

    public Vector2Int yw
    {
        get
        {
            return new Vector2Int(y, w);
        }
        set
        {
            y = value.x;
            w = value.y;
        }
    }

    public Vector3Int xyw
    {
        get
        {
            return new Vector3Int(x, y, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            w = value.z;
        }
    }

    public Vector2Int zw
    {
        get
        {
            return new Vector2Int(z, w);
        }
        set
        {
            z = value.x;
            w = value.y;
        }
    }

    public Vector3Int xzw
    {
        get
        {
            return new Vector3Int(x, z, w);
        }
        set
        {
            x = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector3Int yzw
    {
        get
        {
            return new Vector3Int(y, z, w);
        }
        set
        {
            y = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector4Int xyzw
    {
        get
        {
            return new Vector4Int(x, y, z, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
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

    public Vector2Int ra
    {
        get
        {
            return new Vector2Int(x, w);
        }
        set
        {
            x = value.x;
            w = value.y;
        }
    }

    public Vector2Int ga
    {
        get
        {
            return new Vector2Int(y, w);
        }
        set
        {
            y = value.x;
            w = value.y;
        }
    }

    public Vector3Int rga
    {
        get
        {
            return new Vector3Int(x, y, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            w = value.z;
        }
    }

    public Vector2Int ba
    {
        get
        {
            return new Vector2Int(z, w);
        }
        set
        {
            z = value.x;
            w = value.y;
        }
    }

    public Vector3Int rba
    {
        get
        {
            return new Vector3Int(x, z, w);
        }
        set
        {
            x = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector3Int gba
    {
        get
        {
            return new Vector3Int(y, z, w);
        }
        set
        {
            y = value.x;
            z = value.y;
            w = value.z;
        }
    }

    public Vector4Int rgba
    {
        get
        {
            return new Vector4Int(x, y, z, w);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
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

    public int a
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

    public int Count => 4;

    public int MinElement => Math.Min(Math.Min(x, y), Math.Min(z, w));

    public int MaxElement => Math.Max(Math.Max(x, y), Math.Max(z, w));

    public float Length => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

    public float LengthSqr => ((x * x + y * y) + (z * z + w * w));

    public int Sum => ((x + y) + (z + w));
    #endregion

    #region Static Vectors
    public static Vector4Int Zero { get; } = new Vector4Int(0, 0, 0, 0);

    public static Vector4Int Ones { get; } = new Vector4Int(1, 1, 1, 1);

    public static Vector4Int Left { get; } = new Vector4Int(-1, 0, 0, 0);

    public static Vector4Int Right { get; } = new Vector4Int(1, 0, 0, 0);

    public static Vector4Int Up { get; } = new Vector4Int(0, 1, 0, 0);

    public static Vector4Int Down { get; } = new Vector4Int(0, -1, 0, 0);

    public static Vector4Int Forward { get; } = new Vector4Int(0, 0, -1, 0);

    public static Vector4Int Back { get; } = new Vector4Int(0, 0, 1, 0);

    public static Vector4Int MaxValue { get; } = new Vector4Int(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

    public static Vector4Int MinValue { get; } = new Vector4Int(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
    #endregion

    #region Operators
    public static bool operator ==(Vector4Int lhs, Vector4Int rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector4Int lhs, Vector4Int rhs) => !lhs.Equals(rhs);

    public static Vector4Int operator +(Vector4Int rhs) => rhs;

    public static Vector4Int operator -(Vector4Int rhs) => new Vector4Int(-rhs.x, -rhs.y, -rhs.z, -rhs.w);

    public static Vector4Int operator +(Vector4Int lhs, Vector4Int rhs) => new Vector4Int(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

    public static Vector4Int operator -(Vector4Int lhs, Vector4Int rhs) => new Vector4Int(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

    public static Vector4Int operator *(Vector4Int lhs, int value) => new Vector4Int(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4Int operator *(int value, Vector4Int lhs) => new Vector4Int(lhs.x * value, lhs.y * value, lhs.z * value, lhs.w * value);

    public static Vector4Int operator /(Vector4Int lhs, int value)
    {
        if (value.Equals(0))
        {
            throw new DivideByZeroException();
        }
        return new Vector4Int(lhs.x / value, lhs.y / value, lhs.z / value, lhs.w / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y}, {z}, {w})";

    public bool Equals(Vector4Int rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z) && w.Equals(rhs.w));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector4Int && Equals((Vector4Int)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode()) * 397) ^ w.GetHashCode();
        }
    }

    public static int Dot(Vector4Int lhs, Vector4Int rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

    public static float Distance(Vector4Int lhs, Vector4Int rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector4Int lhs, Vector4Int rhs) => (lhs - rhs).LengthSqr;

    public static Vector4Int Reflect(Vector4Int I, Vector4Int N) => I - 2 * Dot(N, I) * N;

    public static Vector4Int Abs(Vector4Int v) => new Vector4Int(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z), Math.Abs(v.w));

    public static Vector4Int Max(Vector4Int lhs, Vector4Int rhs) => new Vector4Int(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z), Math.Max(lhs.w, rhs.w));

    public static Vector4Int Min(Vector4Int lhs, Vector4Int rhs) => new Vector4Int(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z), Math.Min(lhs.w, rhs.w));

    public static Vector4Int Clamp(Vector4Int v, Vector4Int min, Vector4Int max) => new Vector4Int(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z), Math.Min(Math.Max(v.w, min.w), max.w));

    public static Vector4Int Clamp(Vector4Int v, int min, int max) => new Vector4Int(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max), Math.Min(Math.Max(v.w, min), max));
    #endregion
}
#endregion