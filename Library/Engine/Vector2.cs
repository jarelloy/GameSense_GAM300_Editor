using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Vector2
[StructLayout(LayoutKind.Sequential)]
public struct Vector2
{
    #region Fields
    public float x;
    public float y;
    #endregion

    #region Constructors
    public Vector2(float x1, float y1)
    {
        x = x1;
        y = y1;
    }
    public Vector2(float v)
    {
        this.x = v;
        this.y = v;
    }
    public Vector2(Vector2 v)
    {
        this.x = v.x;
        this.y = v.y;
    }
    public Vector2(Vector3 v2)
    {
        x = v2.x;
        y = v2.y;
    }
    public Vector2(Vector4 v)
    {
        this.x = v.x;
        this.y = v.y;
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Vector2Int(Vector2 v) => new Vector2Int((int)v.x, (int)v.y);

    public static explicit operator Vector3Int(Vector2 v) => new Vector3Int((int)v.x, (int)v.y, 0);

    public static explicit operator Vector4Int(Vector2 v) => new Vector4Int((int)v.x, (int)v.y, 0, 0);

    public static explicit operator Vector3(Vector2 v) => new Vector3((float)v.x, (float)v.y, 0f);

    public static explicit operator Vector4(Vector2 v) => new Vector4((float)v.x, (float)v.y, 0f, 0f);
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
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x = value; break;
                case 1: y = value; break;
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

    public int Count => 2;

    public float MinElement => Math.Min(x, y);

    public float MaxElement => Math.Max(x, y);

    public float Length => (float)Math.Sqrt((x * x + y * y));

    public float LengthSqr => (x * x + y * y);

    public float Sum => (x + y);

    public Vector2 Normalized => this / (float)Length;

    public Vector2 NormalizedSafe => this == Zero ? Zero : this / (float)Length;
    #endregion

    #region Static Vectors
    public static Vector2 Zero { get; } = new Vector2(0f, 0f);
    
    public static Vector2 One { get; } = new Vector2(1f, 1f);

    public static Vector2 Left { get; } = new Vector2(-1f, 0f);

    public static Vector2 Right { get; } = new Vector2(1f, 0f);

    public static Vector2 Up { get; } = new Vector2(0f, 1f);

    public static Vector2 Down { get; } = new Vector2(0f, -1f);

    public static Vector2 MaxValue { get; } = new Vector2(float.MaxValue, float.MaxValue);

    public static Vector2 MinValue { get; } = new Vector2(float.MinValue, float.MinValue);

    public static Vector2 Epsilon { get; } = new Vector2(float.Epsilon, float.Epsilon);

    public static Vector2 NaN { get; } = new Vector2(float.NaN, float.NaN);

    public static Vector2 NegativeInfinity { get; } = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

    public static Vector2 PositiveInfinity { get; } = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
    #endregion

    #region Operators
    public static bool operator ==(Vector2 lhs, Vector2 rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector2 lhs, Vector2 rhs) => !lhs.Equals(rhs);

    public static Vector2 operator +(Vector2 rhs) => rhs;

    public static Vector2 operator -(Vector2 rhs) => new Vector2(-rhs.x, -rhs.y);

    public static Vector2 operator +(Vector2 lhs, Vector2 rhs) => new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);

    public static Vector2 operator -(Vector2 lhs, Vector2 rhs) => new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2 operator *(Vector2 lhs, float value) => new Vector2(lhs.x * value, lhs.y * value);

    public static Vector2 operator *(float value, Vector2 lhs) => new Vector2(lhs.x * value, lhs.y * value);

    public static Vector2 operator / (Vector2 lhs, float value)
    {
        if (value.Equals(0.0f))
        {
            throw new DivideByZeroException();
        }
        return new Vector2(lhs.x / value, lhs.y / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y})";

    public bool Equals(Vector2 rhs) => (x.Equals(rhs.x) && y.Equals(rhs.y));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector2 && Equals((Vector2)obj);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397);
        }
    }

    public static float Dot(Vector2 lhs, Vector2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);

    public static float Distance(Vector2 lhs, Vector2 rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector2 lhs, Vector2 rhs) => (lhs - rhs).LengthSqr;

    public static Vector2 Reflect(Vector2 I, Vector2 N) => I - 2 * Dot(N, I) * N;

    public static float Cross(Vector2 l, Vector2 r) => l.x * r.y - l.y * r.x;

    public static Vector2 Abs(Vector2 v) => new Vector2(Math.Abs(v.x), Math.Abs(v.y));

    public static Vector2 Max(Vector2 lhs, Vector2 rhs) => new Vector2(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));

    public static Vector2 Min(Vector2 lhs, Vector2 rhs) => new Vector2(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y));

    public static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max) => new Vector2(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y));

    public static Vector2 Clamp(Vector2 v, Vector2 min, float max) => new Vector2(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max));

    public static Vector2 Lerp(Vector2 startVec, Vector2 endVec, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);

        float xValue = startVec.x + (endVec.x - startVec.x) * timer;
        float yValue = startVec.y + (endVec.y - startVec.y) * timer;

        return new Vector2(xValue, yValue);
    }

    #endregion
}
#endregion

#region Vector2Int
[StructLayout(LayoutKind.Sequential)]
public struct Vector2Int
{
    #region Fields
    public int x;
    public int y;
    #endregion

    #region Constructors
    public Vector2Int(int x1, int y1)
    {
        x = x1;
        y = y1;
    }
    public Vector2Int(int v)
    {
        this.x = v;
        this.y = v;
    }
    public Vector2Int(Vector2Int v)
    {
        this.x = v.x;
        this.y = v.y;
    }
    public Vector2Int(Vector3Int v2)
    {
        x = v2.x;
        y = v2.y;
    }
    public Vector2Int(Vector4Int v)
    {
        this.x = v.x;
        this.y = v.y;
    }
    #endregion

    #region Conversion Operators
    public static implicit operator Vector2(Vector2Int v) => new Vector2((float)v.x, (float)v.y);

    public static explicit operator Vector3Int(Vector2Int v) => new Vector3Int((int)v.x, (int)v.y, 0);

    public static explicit operator Vector4Int(Vector2Int v) => new Vector4Int((int)v.x, (int)v.y, 0, 0);

    public static explicit operator Vector3(Vector2Int v) => new Vector3((float)v.x, (float)v.y, 0f);

    public static explicit operator Vector4(Vector2Int v) => new Vector4((float)v.x, (float)v.y, 0f, 0f);
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
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x = value; break;
                case 1: y = value; break;
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

    public int Count => 2;

    public int MinElement => Math.Min(x, y);

    public int MaxElement => Math.Max(x, y);

    public float Length => (float)Math.Sqrt((x * x + y * y));

    public float LengthSqr => (x * x + y * y);

    public int Sum => (x + y);
    #endregion

    #region Static Vectors
    public static Vector2Int Zero { get; } = new Vector2Int(0, 0);

    public static Vector2Int One { get; } = new Vector2Int(1, 1);

    public static Vector2Int Left { get; } = new Vector2Int(-1, 0);

    public static Vector2Int Right { get; } = new Vector2Int(1, 0);

    public static Vector2Int Up { get; } = new Vector2Int(0, 1);

    public static Vector2Int Down { get; } = new Vector2Int(0, -1);

    public static Vector2Int MaxValue { get; } = new Vector2Int(int.MaxValue, int.MaxValue);

    public static Vector2Int MinValue { get; } = new Vector2Int(int.MinValue, int.MinValue);
    #endregion

    #region Operators
    public static bool operator ==(Vector2Int lhs, Vector2Int rhs) => lhs.Equals(rhs);

    public static bool operator !=(Vector2Int lhs, Vector2Int rhs) => !lhs.Equals(rhs);

    public static Vector2Int operator +(Vector2Int rhs) => rhs;

    public static Vector2Int operator -(Vector2Int rhs) => new Vector2Int(-rhs.x, -rhs.y);

    public static Vector2Int operator +(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(lhs.x + rhs.x, lhs.y + rhs.y);

    public static Vector2Int operator -(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2Int operator *(Vector2Int lhs, int value) => new Vector2Int(lhs.x * value, lhs.y * value);

    public static Vector2Int operator *(int value, Vector2Int lhs) => new Vector2Int(lhs.x * value, lhs.y * value);

    public static Vector2Int operator /(Vector2Int lhs, int value)
    {
        if (value.Equals(0))
        {
            throw new DivideByZeroException();
        }
        return new Vector2Int(lhs.x / value, lhs.y / value);
    }
    #endregion

    #region Functions
    public override string ToString() => $"({x}, {y})";

    public bool Equals(Vector2 rhs) => (x.Equals(rhs.x) && y.Equals(rhs.y));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Vector2 && Equals((Vector2)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397);
        }
    }

    public static int Dot(Vector2Int lhs, Vector2Int rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);

    public static float Distance(Vector2Int lhs, Vector2Int rhs) => (lhs - rhs).Length;

    public static float DistanceSqr(Vector2Int lhs, Vector2Int rhs) => (lhs - rhs).LengthSqr;

    public static Vector2Int Reflect(Vector2Int I, Vector2Int N) => I - 2 * Dot(N, I) * N;

    public static int Cross(Vector2Int l, Vector2Int r) => l.x * r.y - l.y * r.x;

    public static Vector2Int Abs(Vector2Int v) => new Vector2Int(Math.Abs(v.x), Math.Abs(v.y));

    public static Vector2Int Max(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));

    public static Vector2Int Min(Vector2Int lhs, Vector2Int rhs) => new Vector2Int(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y));

    public static Vector2Int Clamp(Vector2Int v, Vector2Int min, Vector2Int max) => new Vector2Int(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y));

    public static Vector2Int Clamp(Vector2Int v, Vector2Int min, int max) => new Vector2Int(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max));
    #endregion
}
#endregion