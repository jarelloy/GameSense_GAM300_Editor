using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Matrix3
[StructLayout(LayoutKind.Sequential)]
public struct Matrix3
{
    #region Fields
    public float m00; public float m01; public float m02; //1st Column
    public float m10; public float m11; public float m12; //2nd Column
    public float m20; public float m21; public float m22; //3rd Column
    #endregion

    #region Constructors
    public Matrix3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
    {
        this.m00 = m00;
        this.m01 = m01;
        this.m02 = m02;
        this.m10 = m10;
        this.m11 = m11;
        this.m12 = m12;
        this.m20 = m20;
        this.m21 = m21;
        this.m22 = m22;
    }
    public Matrix3(Matrix3 m)
    {
        this.m00 = m.m00;
        this.m01 = m.m01;
        this.m02 = m.m02;
        this.m10 = m.m10;
        this.m11 = m.m11;
        this.m12 = m.m12;
        this.m20 = m.m20;
        this.m21 = m.m21;
        this.m22 = m.m22;
    }
    public Matrix3(Matrix4 m)
    {
        this.m00 = m.m00;
        this.m01 = m.m01;
        this.m02 = m.m02;
        this.m10 = m.m10;
        this.m11 = m.m11;
        this.m12 = m.m12;
        this.m20 = m.m20;
        this.m21 = m.m21;
        this.m22 = m.m22;
    }
    public Matrix3(Vector3 c0, Vector3 c1)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m20 = 0f;
        this.m21 = 0f;
        this.m22 = 1f;
    }
    public Matrix3(Vector3 c0, Vector3 c1, Vector3 c2)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m20 = c2.x;
        this.m21 = c2.y;
        this.m22 = c2.z;
    }
    public Matrix3(Quaternion q)
           : this(q.ToMatrix3)
    {
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Matrix3(Quaternion q) => q.ToMatrix3;
    #endregion

    #region Indexer
    public float this[int fieldIndex]
    {
        get
        {
            switch (fieldIndex)
            {
                case 0: return m00;
                case 1: return m01;
                case 2: return m02;
                case 3: return m10;
                case 4: return m11;
                case 5: return m12;
                case 6: return m20;
                case 7: return m21;
                case 8: return m22;
                default: throw new ArgumentOutOfRangeException("fieldIndex");
            }
        }
        set
        {
            switch (fieldIndex)
            {
                case 0: this.m00 = value; break;
                case 1: this.m01 = value; break;
                case 2: this.m02 = value; break;
                case 3: this.m10 = value; break;
                case 4: this.m11 = value; break;
                case 5: this.m12 = value; break;
                case 6: this.m20 = value; break;
                case 7: this.m21 = value; break;
                case 8: this.m22 = value; break;
                default: throw new ArgumentOutOfRangeException("fieldIndex");
            }
        }
    }

    public float this[int col, int row]
    {
        get
        {
            return this[col * 3 + row];
        }
        set
        {
            this[col * 3 + row] = value;
        }
    }
    #endregion

    #region Properties
    public Vector3 Column0
    {
        get
        {
            return new Vector3(m00, m01, m02);
        }
        set
        {
            m00 = value.x;
            m01 = value.y;
            m02 = value.z;
        }
    }

    public Vector3 Column1
    {
        get
        {
            return new Vector3(m10, m11, m12);
        }
        set
        {
            m10 = value.x;
            m11 = value.y;
            m12 = value.z;
        }
    }

    public Vector3 Column2
    {
        get
        {
            return new Vector3(m20, m21, m22);
        }
        set
        {
            m20 = value.x;
            m21 = value.y;
            m22 = value.z;
        }
    }

    public Vector3 Row0
    {
        get
        {
            return new Vector3(m00, m10, m20);
        }
        set
        {
            m00 = value.x;
            m10 = value.y;
            m20 = value.z;
        }
    }

    public Vector3 Row1
    {
        get
        {
            return new Vector3(m01, m11, m21);
        }
        set
        {
            m01 = value.x;
            m11 = value.y;
            m21 = value.z;
        }
    }

    public Vector3 Row2
    {
        get
        {
            return new Vector3(m02, m12, m22);
        }
        set
        {
            m02 = value.x;
            m12 = value.y;
            m22 = value.z;
        }
    }

    public Quaternion ToQuaternion => Quaternion.FromMatrix3(this);
    #endregion

    #region Static Matrices
    public static Matrix3 Zero { get; } = new Matrix3(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);

    public static Matrix3 One { get; } = new Matrix3(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);

    public static Matrix3 Identity { get; } = new Matrix3(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);
    #endregion

    #region Operators
    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs) => new Matrix3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + lhs.m20 * rhs.m02), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + lhs.m21 * rhs.m02), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + lhs.m22 * rhs.m02), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + lhs.m20 * rhs.m12), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + lhs.m21 * rhs.m12), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + lhs.m22 * rhs.m12), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + lhs.m20 * rhs.m22), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + lhs.m21 * rhs.m22), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + lhs.m22 * rhs.m22));

    public static Vector3 operator *(Matrix3 m, Vector3 v) => new Vector3(((m.m00 * v.x + m.m10 * v.y) + m.m20 * v.z), ((m.m01 * v.x + m.m11 * v.y) + m.m21 * v.z), ((m.m02 * v.x + m.m12 * v.y) + m.m22 * v.z));

    public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs) => new Matrix3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22);

    public static Matrix3 operator +(Matrix3 lhs, float rhs) => new Matrix3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs);

    public static Matrix3 operator +(float lhs, Matrix3 rhs) => new Matrix3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22);

    public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs) => new Matrix3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22);

    public static Matrix3 operator -(Matrix3 lhs, float rhs) => new Matrix3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs);

    public static Matrix3 operator -(float lhs, Matrix3 rhs) => new Matrix3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22);

    public static Matrix3 operator /(Matrix3 lhs, float rhs) => new Matrix3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs);

    public static Matrix3 operator /(float lhs, Matrix3 rhs) => new Matrix3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22);

    public static Matrix3 operator *(Matrix3 lhs, float rhs) => new Matrix3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs);

    public static Matrix3 operator *(float lhs, Matrix3 rhs) => new Matrix3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22);
    #endregion

    #region Functions
    public int Count => 9;

    public bool Equals(Matrix3 rhs) => ((((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && m02.Equals(rhs.m02)) && (m10.Equals(rhs.m10) && m11.Equals(rhs.m11))) && ((m12.Equals(rhs.m12) && m20.Equals(rhs.m20)) && (m21.Equals(rhs.m21) && m22.Equals(rhs.m22))));

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Matrix3 && Equals((Matrix3)obj);
    }

    public static bool operator ==(Matrix3 lhs, Matrix3 rhs) => lhs.Equals(rhs);

    public static bool operator !=(Matrix3 lhs, Matrix3 rhs) => !lhs.Equals(rhs);

    public override int GetHashCode()
    {
        unchecked
        {
            return ((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode();
        }
    }

    public Matrix3 Transposed => new Matrix3(m00, m10, m20, m01, m11, m21, m02, m12, m22);

    public float Determinant => m00 * (m11 * m22 - m21 * m12) - m10 * (m01 * m22 - m21 * m02) + m20 * (m01 * m12 - m11 * m02);

    public Matrix3 Adjugate => new Matrix3(m11 * m22 - m21 * m12, -m01 * m22 + m21 * m02, m01 * m12 - m11 * m02, -m10 * m22 + m20 * m12, m00 * m22 - m20 * m02, -m00 * m12 + m10 * m02, m10 * m21 - m20 * m11, -m00 * m21 + m20 * m01, m00 * m11 - m10 * m01);

    public Matrix3 Inverse => Adjugate / Determinant;
    #endregion
}
#endregion