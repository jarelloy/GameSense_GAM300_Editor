using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Quaternion
[StructLayout(LayoutKind.Sequential)]
public struct Quaternion
{
    #region Fields
    public float w;
    public float x;
    public float y;
    public float z;
    #endregion

    #region Constructors
    public Quaternion(float w, float x, float y, float z)
    {
        this.w = w;
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Quaternion(Quaternion q)
    {
        this.w = q.w;
        this.x = q.x;
        this.y = q.y;
        this.z = q.z;
    }
    public Quaternion(float s, Vector3 v)
    {
        this.w = s;
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    public Quaternion(Vector3 u, Vector3 v)
    {
        var localW = Vector3.Cross(u, v);
        var dot = Vector3.Dot(u, v);
        var q = new Quaternion(1f + dot, localW.x, localW.y, localW.z).Normalized;
        this.w = q.w;
        this.x = q.x;
        this.y = q.y;
        this.z = q.z;
    }
    public Quaternion(Vector3 eulerAngle)
    {
        var c = Vector3.Cos(eulerAngle / 2);
        var s = Vector3.Sin(eulerAngle / 2);
        this.w = c.x * c.y * c.z + s.x * s.y * s.z;
        this.x = s.x * c.y * c.z - c.x * s.y * s.z;
        this.y = c.x * s.y * c.z + s.x * c.y * s.z;
        this.z = c.x * c.y * s.z - s.x * s.y * c.z;
    }
    public Quaternion(Matrix4 m)
          : this(FromMatrix4(m))
    {
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Quaternion(Matrix4 m) => FromMatrix4(m);
    #endregion

    #region Index
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return w;
                case 1: return x;
                case 2: return y;
                case 3: return z;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: w = value; break;
                case 1: x = value; break;
                case 2: y = value; break;
                case 3: z = value; break;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
    }
    #endregion

    #region Properties
    public int Count => 4;

    public float Length => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

    public float LengthSqr => ((x * x + y * y) + (z * z + w * w));

    public Quaternion Normalized => this / (float)Length;

    public Quaternion NormalizedSafe => this == Zero ? Identity : this / (float)Length;

    public double Angle => Math.Acos((double)w) * 2.0;

    public Vector3 Axis
    {
        get
        {
            var s1 = 1 - w * w;
            if (s1 < 0) return Vector3.Back;
            var s2 = 1 / Math.Sqrt(s1);
            return new Vector3((float)(x * s2), (float)(y * s2), (float)(z * s2));
        }
    }

    public double Yaw => Math.Asin(-2.0 * (double)(x * z - w * y));

    public double Pitch => Math.Atan2(2.0 * (double)(y * z + w * x), (double)(w * w - x * x - y * y + z * z));

    public double Roll => Math.Atan2(2.0 * (double)(x * y + w * z), (double)(w * w + x * x - y * y - z * z));

    public Vector3 EulerAngles => new Vector3((float)Pitch, (float)Yaw, (float)Roll);

    public Matrix3 ToMatrix3 => new Matrix3(1 - 2 * (y * y + z * z), 2 * (x * y + w * z), 2 * (x * z - w * y), 2 * (x * y - w * z), 1 - 2 * (x * x + z * z), 2 * (y * z + w * x), 2 * (x * z + w * y), 2 * (y * z - w * x), 1 - 2 * (x * x + y * y));

    public Matrix4 ToMatrix4 => new Matrix4(ToMatrix3);

    public Quaternion Conjugate => new Quaternion(w, -x, -y, -z);

    public Quaternion Inverse => Conjugate / LengthSqr;
    #endregion

    #region Static Vectors
    public static Quaternion Zero { get; } = new Quaternion(0f, 0f, 0f, 0f);

    public static Quaternion Identity { get; } = new Quaternion(1f, 0f, 0f, 0f);
    #endregion

    #region Operators
    public static bool operator ==(Quaternion lhs, Quaternion rhs) => lhs.Equals(rhs);

    public static bool operator !=(Quaternion lhs, Quaternion rhs) => !lhs.Equals(rhs);

    public static Quaternion operator *(Quaternion p, Quaternion q) => new Quaternion(p.w * q.w - p.x * q.x - p.y * q.y - p.z * q.z, p.w * q.x + p.x * q.w + p.y * q.z - p.z * q.y, p.w * q.y + p.y * q.w + p.z * q.x - p.x * q.z, p.w * q.z + p.z * q.w + p.x * q.y - p.y * q.x);

    public static Quaternion operator +(Quaternion v) => v;

    public static Quaternion operator -(Quaternion v) => new Quaternion(-v.w , - v.x, -v.y, -v.z);

    public static Quaternion operator +(Quaternion lhs, Quaternion rhs) => new Quaternion(lhs.w + rhs.w, lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

    public static Quaternion operator +(Quaternion lhs, float rhs) => new Quaternion(lhs.w + rhs, lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

    public static Quaternion operator +(float lhs, Quaternion rhs) => new Quaternion(lhs + rhs.w, lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

    public static Quaternion operator -(Quaternion lhs, Quaternion rhs) => new Quaternion(lhs.w - rhs.w, lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

    public static Quaternion operator -(Quaternion lhs, float rhs) => new Quaternion(lhs.w - rhs, lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

    public static Quaternion operator -(float lhs, Quaternion rhs) => new Quaternion(lhs - rhs.w, lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

    public static Quaternion operator *(Quaternion lhs, float rhs) => new Quaternion(lhs.w * rhs, lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

    public static Quaternion operator *(float lhs, Quaternion rhs) => new Quaternion(lhs * rhs.w, lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

    public static Quaternion operator /(Quaternion lhs, float rhs) => new Quaternion(lhs.w / rhs, lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

    public static Vector3 operator *(Quaternion q, Vector3 v)
    {
        var qv = new Vector3(q.x, q.y, q.z);
        var uv = Vector3.Cross(qv, v);
        var uuv = Vector3.Cross(qv, uv);
        return v + ((uv * q.w) + uuv) * 2;
    }

    public static Vector4 operator *(Quaternion q, Vector4 v) => new Vector4(q * new Vector3(v), v.w);

    public static Vector3 operator *(Vector3 v, Quaternion q) => q.Inverse * v;

    public static Vector4 operator *(Vector4 v, Quaternion q) => q.Inverse * v;
    #endregion

    #region Functions
    public override string ToString() => $"({w}, {x}, {y}, {z})";

    public bool Equals(Quaternion rhs) => ((w.Equals(rhs.w) && x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Quaternion && Equals((Quaternion)obj);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return ((((((w.GetHashCode()) * 397) ^ x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode();
        }
    }

    public Quaternion Rotated(float angle, Vector3 v) => this * FromAxisAngle(angle, v);

    public static float Dot(Quaternion lhs, Quaternion rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

    public static Quaternion FromAxisAngle(float angle, Vector3 v)
    {
        var s = Math.Sin((double)angle * 0.5);
        var c = Math.Cos((double)angle * 0.5);
        return new Quaternion((float)c, (float)((double)v.x * s), (float)((double)v.y * s), (float)((double)v.z * s));
    }

    public static Quaternion FromMatrix3(Matrix3 m)
    {
        var fourXSquaredMinus1 = m.m00 - m.m11 - m.m22;
        var fourYSquaredMinus1 = m.m11 - m.m00 - m.m22;
        var fourZSquaredMinus1 = m.m22 - m.m00 - m.m11;
        var fourWSquaredMinus1 = m.m00 + m.m11 + m.m22;
        var biggestIndex = 0;
        var fourBiggestSquaredMinus1 = fourWSquaredMinus1;
        if (fourXSquaredMinus1 > fourBiggestSquaredMinus1)
        {
            fourBiggestSquaredMinus1 = fourXSquaredMinus1;
            biggestIndex = 1;
        }
        if (fourYSquaredMinus1 > fourBiggestSquaredMinus1)
        {
            fourBiggestSquaredMinus1 = fourYSquaredMinus1;
            biggestIndex = 2;
        }
        if (fourZSquaredMinus1 > fourBiggestSquaredMinus1)
        {
            fourBiggestSquaredMinus1 = fourZSquaredMinus1;
            biggestIndex = 3;
        }
        var biggestVal = Math.Sqrt((double)fourBiggestSquaredMinus1 + 1.0) * 0.5;
        var mult = 0.25 / biggestVal;
        switch (biggestIndex)
        {
            case 0: return new Quaternion((float)(biggestVal), (float)((double)(m.m12 - m.m21) * mult), (float)((double)(m.m20 - m.m02) * mult), (float)((double)(m.m01 - m.m10) * mult));
            case 1: return new Quaternion((float)((double)(m.m12 - m.m21) * mult), (float)(biggestVal), (float)((double)(m.m01 + m.m10) * mult), (float)((double)(m.m20 + m.m02) * mult));
            case 2: return new Quaternion((float)((double)(m.m20 - m.m02) * mult), (float)((double)(m.m01 + m.m10) * mult), (float)(biggestVal), (float)((double)(m.m12 + m.m21) * mult));
            default: return new Quaternion((float)((double)(m.m01 - m.m10) * mult), (float)((double)(m.m20 + m.m02) * mult), (float)((double)(m.m12 + m.m21) * mult), (float)(biggestVal));
        }
    }

    public static Quaternion FromMatrix4(Matrix4 m) => FromMatrix3(new Matrix3(m));

    public static Quaternion Cross(Quaternion q1, Quaternion q2) => new Quaternion(q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z, q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y, q1.w * q2.y + q1.y * q2.w + q1.z * q2.x - q1.x * q2.z, q1.w * q2.z + q1.z * q2.w + q1.x * q2.y - q1.y * q2.x);

    public static Quaternion SLerp(Quaternion x, Quaternion y, float a)
    {
        var z = y;
        var cosTheta = (double)Dot(x, y);
        if (cosTheta < 0) { z = -y; cosTheta = -cosTheta; }
        if (cosTheta > 1 - float.Epsilon)
            return Lerp(x, z, a);
        else
        {
            var angle = Math.Acos((double)cosTheta);
            return (((float)Math.Sin((1 - (double)a) * angle) * x + (float)Math.Sin((double)a * angle) * z) / (float)Math.Sin(angle));
        }
    }

    public static Quaternion Lerp(Quaternion min, Quaternion max, float a) => new Quaternion(min.w * (1 - a) + max.w * a, min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);
    #endregion
}
#endregion