using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region Matrix4
[StructLayout(LayoutKind.Sequential)]
public struct Matrix4
{
    #region Fields
    public float m00; public float m01; public float m02; public float m03; //1st Column
    public float m10; public float m11; public float m12; public float m13; //2nd Column
    public float m20; public float m21; public float m22; public float m23; //3rd Column
    public float m30; public float m31; public float m32; public float m33; //4th Column
    #endregion

    #region Constructors
    public Matrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
    {
        this.m00 = m00;
        this.m01 = m01;
        this.m02 = m02;
        this.m03 = m03;
        this.m10 = m10;
        this.m11 = m11;
        this.m12 = m12;
        this.m13 = m13;
        this.m20 = m20;
        this.m21 = m21;
        this.m22 = m22;
        this.m23 = m23;
        this.m30 = m30;
        this.m31 = m31;
        this.m32 = m32;
        this.m33 = m33;
    }
    public Matrix4(Matrix3 m)
    {
        this.m00 = m.m00;
        this.m01 = m.m01;
        this.m02 = m.m02;
        this.m03 = 0f;
        this.m10 = m.m10;
        this.m11 = m.m11;
        this.m12 = m.m12;
        this.m13 = 0f;
        this.m20 = m.m20;
        this.m21 = m.m21;
        this.m22 = m.m22;
        this.m23 = 0f;
        this.m30 = 0f;
        this.m31 = 0f;
        this.m32 = 0f;
        this.m33 = 1f;
    }
    public Matrix4(Matrix4 m)
    {
        this.m00 = m.m00;
        this.m01 = m.m01;
        this.m02 = m.m02;
        this.m03 = m.m03;
        this.m10 = m.m10;
        this.m11 = m.m11;
        this.m12 = m.m12;
        this.m13 = m.m13;
        this.m20 = m.m20;
        this.m21 = m.m21;
        this.m22 = m.m22;
        this.m23 = m.m23;
        this.m30 = m.m30;
        this.m31 = m.m31;
        this.m32 = m.m32;
        this.m33 = m.m33;
    }
    public Matrix4(Vector3 c0, Vector3 c1)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = 0f;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = 0f;
        this.m20 = 0f;
        this.m21 = 0f;
        this.m22 = 1f;
        this.m23 = 0f;
        this.m30 = 0f;
        this.m31 = 0f;
        this.m32 = 0f;
        this.m33 = 1f;
    }
    public Matrix4(Vector3 c0, Vector3 c1, Vector3 c2)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = 0f;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = 0f;
        this.m20 = c2.x;
        this.m21 = c2.y;
        this.m22 = c2.z;
        this.m23 = 0f;
        this.m30 = 0f;
        this.m31 = 0f;
        this.m32 = 0f;
        this.m33 = 1f;
    }
    public Matrix4(Vector3 c0, Vector3 c1, Vector3 c2, Vector3 c3)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = 0f;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = 0f;
        this.m20 = c2.x;
        this.m21 = c2.y;
        this.m22 = c2.z;
        this.m23 = 0f;
        this.m30 = c3.x;
        this.m31 = c3.y;
        this.m32 = c3.z;
        this.m33 = 1f;
    }
    public Matrix4(Vector4 c0, Vector4 c1)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = c0.w;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = c1.w;
        this.m20 = 0f;
        this.m21 = 0f;
        this.m22 = 1f;
        this.m23 = 0f;
        this.m30 = 0f;
        this.m31 = 0f;
        this.m32 = 0f;
        this.m33 = 1f;
    }
    public Matrix4(Vector4 c0, Vector4 c1, Vector4 c2)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = c0.w;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = c1.w;
        this.m20 = c2.x;
        this.m21 = c2.y;
        this.m22 = c2.z;
        this.m23 = c2.w;
        this.m30 = 0f;
        this.m31 = 0f;
        this.m32 = 0f;
        this.m33 = 1f;
    }
    public Matrix4(Vector4 c0, Vector4 c1, Vector4 c2, Vector4 c3)
    {
        this.m00 = c0.x;
        this.m01 = c0.y;
        this.m02 = c0.z;
        this.m03 = c0.w;
        this.m10 = c1.x;
        this.m11 = c1.y;
        this.m12 = c1.z;
        this.m13 = c1.w;
        this.m20 = c2.x;
        this.m21 = c2.y;
        this.m22 = c2.z;
        this.m23 = c2.w;
        this.m30 = c3.x;
        this.m31 = c3.y;
        this.m32 = c3.z;
        this.m33 = c3.w;
    }

    public Matrix4(Quaternion q)
      : this(q.ToMatrix4)
    {
    }
    #endregion

    #region Conversion Operators
    public static explicit operator Matrix4(Quaternion q) => q.ToMatrix4;
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
                case 3: return m03;
                case 4: return m10;
                case 5: return m11;
                case 6: return m12;
                case 7: return m13;
                case 8: return m20;
                case 9: return m21;
                case 10: return m22;
                case 11: return m23;
                case 12: return m30;
                case 13: return m31;
                case 14: return m32;
                case 15: return m33;
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
                case 3: this.m03 = value; break;
                case 4: this.m10 = value; break;
                case 5: this.m11 = value; break;
                case 6: this.m12 = value; break;
                case 7: this.m13 = value; break;
                case 8: this.m20 = value; break;
                case 9: this.m21 = value; break;
                case 10: this.m22 = value; break;
                case 11: this.m23 = value; break;
                case 12: this.m30 = value; break;
                case 13: this.m31 = value; break;
                case 14: this.m32 = value; break;
                case 15: this.m33 = value; break;
                default: throw new ArgumentOutOfRangeException("fieldIndex");
            }
        }
    }

    public float this[int col, int row]
    {
        get
        {
            return this[col * 4 + row];
        }
        set
        {
            this[col * 4 + row] = value;
        }
    }
    #endregion

    #region Properties
    public Vector4 Column0
    {
        get
        {
            return new Vector4(m00, m01, m02, m03);
        }
        set
        {
            m00 = value.x;
            m01 = value.y;
            m02 = value.z;
            m03 = value.w;
        }
    }

    public Vector4 Column1
    {
        get
        {
            return new Vector4(m10, m11, m12, m13);
        }
        set
        {
            m10 = value.x;
            m11 = value.y;
            m12 = value.z;
            m13 = value.w;
        }
    }

    public Vector4 Column2
    {
        get
        {
            return new Vector4(m20, m21, m22, m23);
        }
        set
        {
            m20 = value.x;
            m21 = value.y;
            m22 = value.z;
            m23 = value.w;
        }
    }

    public Vector4 Column3
    {
        get
        {
            return new Vector4(m30, m31, m32, m33);
        }
        set
        {
            m30 = value.x;
            m31 = value.y;
            m32 = value.z;
            m33 = value.w;
        }
    }

    public Vector4 Row0
    {
        get
        {
            return new Vector4(m00, m10, m20, m30);
        }
        set
        {
            m00 = value.x;
            m10 = value.y;
            m20 = value.z;
            m30 = value.w;
        }
    }

    public Vector4 Row1
    {
        get
        {
            return new Vector4(m01, m11, m21, m31);
        }
        set
        {
            m01 = value.x;
            m11 = value.y;
            m21 = value.z;
            m31 = value.w;
        }
    }

    public Vector4 Row2
    {
        get
        {
            return new Vector4(m02, m12, m22, m32);
        }
        set
        {
            m02 = value.x;
            m12 = value.y;
            m22 = value.z;
            m32 = value.w;
        }
    }

    public Vector4 Row3
    {
        get
        {
            return new Vector4(m03, m13, m23, m33);
        }
        set
        {
            m03 = value.x;
            m13 = value.y;
            m23 = value.z;
            m33 = value.w;
        }
    }

    public Quaternion ToQuaternion => Quaternion.FromMatrix4(this);
    #endregion

    #region Static Matrices
    public static Matrix4 Zero { get; } = new Matrix4(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);

    public static Matrix4 One { get; } = new Matrix4(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);

    public static Matrix4 Identity { get; } = new Matrix4(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
    #endregion

    #region Operators
    public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs) => new Matrix4(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01) + (lhs.m23 * rhs.m02 + lhs.m33 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11) + (lhs.m23 * rhs.m12 + lhs.m33 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)), ((lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21) + (lhs.m23 * rhs.m22 + lhs.m33 * rhs.m23)), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32 + lhs.m30 * rhs.m33)), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32 + lhs.m31 * rhs.m33)), ((lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31) + (lhs.m22 * rhs.m32 + lhs.m32 * rhs.m33)), ((lhs.m03 * rhs.m30 + lhs.m13 * rhs.m31) + (lhs.m23 * rhs.m32 + lhs.m33 * rhs.m33)));

    public static Vector4 operator *(Matrix4 m, Vector4 v) => new Vector4(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30 * v.w)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31 * v.w)), ((m.m02 * v.x + m.m12 * v.y) + (m.m22 * v.z + m.m32 * v.w)), ((m.m03 * v.x + m.m13 * v.y) + (m.m23 * v.z + m.m33 * v.w)));

    public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs) => new Matrix4(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m03 + rhs.m03, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23, lhs.m30 + rhs.m30, lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33);

    public static Matrix4 operator +(Matrix4 lhs, float rhs) => new Matrix4(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m03 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m13 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs, lhs.m23 + rhs, lhs.m30 + rhs, lhs.m31 + rhs, lhs.m32 + rhs, lhs.m33 + rhs);

    public static Matrix4 operator +(float lhs, Matrix4 rhs) => new Matrix4(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m03, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m13, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22, lhs + rhs.m23, lhs + rhs.m30, lhs + rhs.m31, lhs + rhs.m32, lhs + rhs.m33);

    public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs) => new Matrix4(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m03 - rhs.m03, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23, lhs.m30 - rhs.m30, lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33);

    public static Matrix4 operator -(Matrix4 lhs, float rhs) => new Matrix4(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m03 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m13 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs, lhs.m23 - rhs, lhs.m30 - rhs, lhs.m31 - rhs, lhs.m32 - rhs, lhs.m33 - rhs);

    public static Matrix4 operator -(float lhs, Matrix4 rhs) => new Matrix4(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m03, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m13, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22, lhs - rhs.m23, lhs - rhs.m30, lhs - rhs.m31, lhs - rhs.m32, lhs - rhs.m33);

    public static Matrix4 operator /(Matrix4 lhs, float rhs) => new Matrix4(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m03 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m13 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs, lhs.m23 / rhs, lhs.m30 / rhs, lhs.m31 / rhs, lhs.m32 / rhs, lhs.m33 / rhs);

    public static Matrix4 operator /(float lhs, Matrix4 rhs) => new Matrix4(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m03, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m13, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22, lhs / rhs.m23, lhs / rhs.m30, lhs / rhs.m31, lhs / rhs.m32, lhs / rhs.m33);

    public static Matrix4 operator *(Matrix4 lhs, float rhs) => new Matrix4(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m03 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m13 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs, lhs.m23 * rhs, lhs.m30 * rhs, lhs.m31 * rhs, lhs.m32 * rhs, lhs.m33 * rhs);

    public static Matrix4 operator *(float lhs, Matrix4 rhs) => new Matrix4(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m03, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m13, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22, lhs * rhs.m23, lhs * rhs.m30, lhs * rhs.m31, lhs * rhs.m32, lhs * rhs.m33);
    #endregion

    #region Functions
    public int Count => 16;

    public bool Equals(Matrix4 rhs) => ((((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && (m02.Equals(rhs.m02) && m03.Equals(rhs.m03))) && ((m10.Equals(rhs.m10) && m11.Equals(rhs.m11)) && (m12.Equals(rhs.m12) && m13.Equals(rhs.m13)))) && (((m20.Equals(rhs.m20) && m21.Equals(rhs.m21)) && (m22.Equals(rhs.m22) && m23.Equals(rhs.m23))) && ((m30.Equals(rhs.m30) && m31.Equals(rhs.m31)) && (m32.Equals(rhs.m32) && m33.Equals(rhs.m33)))));
    
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Matrix4 && Equals((Matrix4)obj);
    }

    public static bool operator ==(Matrix4 lhs, Matrix4 rhs) => lhs.Equals(rhs);

    public static bool operator !=(Matrix4 lhs, Matrix4 rhs) => !lhs.Equals(rhs);

    public override int GetHashCode()
    {
        unchecked
        {
            return ((((((((((((((((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m03.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m13.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode()) * 397) ^ m23.GetHashCode()) * 397) ^ m30.GetHashCode()) * 397) ^ m31.GetHashCode()) * 397) ^ m32.GetHashCode()) * 397) ^ m33.GetHashCode();
        }
    }

    public Matrix4 Transposed => new Matrix4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33);

    public float Determinant => m00 * (m11 * (m22 * m33 - m32 * m23) - m21 * (m12 * m33 - m32 * m13) + m31 * (m12 * m23 - m22 * m13)) - m10 * (m01 * (m22 * m33 - m32 * m23) - m21 * (m02 * m33 - m32 * m03) + m31 * (m02 * m23 - m22 * m03)) + m20 * (m01 * (m12 * m33 - m32 * m13) - m11 * (m02 * m33 - m32 * m03) + m31 * (m02 * m13 - m12 * m03)) - m30 * (m01 * (m12 * m23 - m22 * m13) - m11 * (m02 * m23 - m22 * m03) + m21 * (m02 * m13 - m12 * m03));

    public Matrix4 Adjugate => new Matrix4(m11 * (m22 * m33 - m32 * m23) - m21 * (m12 * m33 - m32 * m13) + m31 * (m12 * m23 - m22 * m13), -m01 * (m22 * m33 - m32 * m23) + m21 * (m02 * m33 - m32 * m03) - m31 * (m02 * m23 - m22 * m03), m01 * (m12 * m33 - m32 * m13) - m11 * (m02 * m33 - m32 * m03) + m31 * (m02 * m13 - m12 * m03), -m01 * (m12 * m23 - m22 * m13) + m11 * (m02 * m23 - m22 * m03) - m21 * (m02 * m13 - m12 * m03), -m10 * (m22 * m33 - m32 * m23) + m20 * (m12 * m33 - m32 * m13) - m30 * (m12 * m23 - m22 * m13), m00 * (m22 * m33 - m32 * m23) - m20 * (m02 * m33 - m32 * m03) + m30 * (m02 * m23 - m22 * m03), -m00 * (m12 * m33 - m32 * m13) + m10 * (m02 * m33 - m32 * m03) - m30 * (m02 * m13 - m12 * m03), m00 * (m12 * m23 - m22 * m13) - m10 * (m02 * m23 - m22 * m03) + m20 * (m02 * m13 - m12 * m03), m10 * (m21 * m33 - m31 * m23) - m20 * (m11 * m33 - m31 * m13) + m30 * (m11 * m23 - m21 * m13), -m00 * (m21 * m33 - m31 * m23) + m20 * (m01 * m33 - m31 * m03) - m30 * (m01 * m23 - m21 * m03), m00 * (m11 * m33 - m31 * m13) - m10 * (m01 * m33 - m31 * m03) + m30 * (m01 * m13 - m11 * m03), -m00 * (m11 * m23 - m21 * m13) + m10 * (m01 * m23 - m21 * m03) - m20 * (m01 * m13 - m11 * m03), -m10 * (m21 * m32 - m31 * m22) + m20 * (m11 * m32 - m31 * m12) - m30 * (m11 * m22 - m21 * m12), m00 * (m21 * m32 - m31 * m22) - m20 * (m01 * m32 - m31 * m02) + m30 * (m01 * m22 - m21 * m02), -m00 * (m11 * m32 - m31 * m12) + m10 * (m01 * m32 - m31 * m02) - m30 * (m01 * m12 - m11 * m02), m00 * (m11 * m22 - m21 * m12) - m10 * (m01 * m22 - m21 * m02) + m20 * (m01 * m12 - m11 * m02));

    public Matrix4 Inverse => Adjugate / Determinant;

    public static Matrix4 Frustum(float left, float right, float bottom, float top, float nearVal, float farVal)
    {
        Matrix4 m = Identity;
        m.m00 = (2 * nearVal) / (right - left);
        m.m11 = (2 * nearVal) / (top - bottom);
        m.m20 = (right + left) / (right - left);
        m.m21 = (top + bottom) / (top - bottom);
        m.m22 = -(farVal + nearVal) / (farVal - nearVal);
        m.m23 = -1;
        m.m32 = -(2 * farVal * nearVal) / (farVal - nearVal);
        return m;
    }

    public static Matrix4 InfinitePerspective(float fovy, float aspect, float zNear)
    {
        double range = Math.Tan((double)fovy / 2.0) * (double)zNear;
        double l = -range * (double)aspect;
        double r = range * (double)aspect;
        double b = -range;
        double t = range;
        Matrix4 m = Identity;
        m.m00 = (float)(((2.0) * (double)zNear) / (r - l));
        m.m11 = (float)(((2.0) * (double)zNear) / (t - b));
        m.m22 = (float)(-(1.0));
        m.m23 = (float)(-(1.0));
        m.m32 = (float)(-(2.0) * (double)zNear);
        return m;
    }

    public static Matrix4 LookAt(Vector3 eye, Vector3 center, Vector3 up)
    {
        Vector3 f = (center - eye).Normalized;
        Vector3 s = Vector3.Cross(f, up).Normalized;
        Vector3 u = Vector3.Cross(s, f);
        Matrix4 m = Identity;
        m.m00 = s.x;
        m.m10 = s.y;
        m.m20 = s.z;
        m.m01 = u.x;
        m.m11 = u.y;
        m.m21 = u.z;
        m.m02 = -f.x;
        m.m12 = -f.y;
        m.m22 = -f.z;
        m.m30 = -Vector3.Dot(s, eye);
        m.m31 = -Vector3.Dot(u, eye);
        m.m32 = Vector3.Dot(f, eye);
        return m;
    }

    public static Matrix4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        Matrix4 m = Identity;
        m.m00 = 2 / (right - left);
        m.m11 = 2 / (top - bottom);
        m.m22 = -2 / (zFar - zNear);
        m.m30 = -(right + left) / (right - left);
        m.m31 = -(top + bottom) / (top - bottom);
        m.m32 = -(zFar + zNear) / (zFar - zNear);
        return m;
    }

    public static Matrix4 Ortho(float left, float right, float bottom, float top)
    {
        Matrix4 m = Identity;
        m.m00 = 2 / (right - left);
        m.m11 = 2 / (top - bottom);
        m.m22 = -1;
        m.m30 = -(right + left) / (right - left);
        m.m31 = -(top + bottom) / (top - bottom);
        return m;
    }

    public static Matrix4 Perspective(float fovy, float aspect, float zNear, float zFar)
    {
        double tanHalfFovy = Math.Tan((double)fovy / 2.0);
        Matrix4 m = Zero;
        m.m00 = (float)(1 / ((double)aspect * tanHalfFovy));
        m.m11 = (float)(1 / (tanHalfFovy));
        m.m22 = (float)(-(zFar + zNear) / (zFar - zNear));
        m.m23 = (float)(-1);
        m.m32 = (float)(-(2 * zFar * zNear) / (zFar - zNear));
        return m;
    }

    public static Matrix4 PerspectiveFov(float fov, float width, float height, float zNear, float zFar)
    {
        if (width <= 0) throw new ArgumentOutOfRangeException("width");
        if (height <= 0) throw new ArgumentOutOfRangeException("height");
        if (fov <= 0) throw new ArgumentOutOfRangeException("fov");
        double h = Math.Cos((double)fov / 2.0) / Math.Sin((double)fov / 2.0);
        double w = h * (double)(height / width);
        Matrix4 m = Zero;
        m.m00 = (float)w;
        m.m11 = (float)h;
        m.m22 = -(zFar + zNear) / (zFar - zNear);
        m.m23 = -1;
        m.m32 = -(2 * zFar * zNear) / (zFar - zNear);
        return m;
    }

    public static Matrix4 Rotate(float angle, Vector3 v)
    {
        float c = (float)Math.Cos((double)angle);
        float s = (float)Math.Sin((double)angle);

        Vector3 axis = v.Normalized;
        Vector3 temp = (1 - c) * axis;

        Matrix4 m = Identity;
        m.m00 = c + temp.x * axis.x;
        m.m01 = 0 + temp.x * axis.y + s * axis.z;
        m.m02 = 0 + temp.x * axis.z - s * axis.y;

        m.m10 = 0 + temp.y * axis.x - s * axis.z;
        m.m11 = c + temp.y * axis.y;
        m.m12 = 0 + temp.y * axis.z + s * axis.x;

        m.m20 = 0 + temp.z * axis.x + s * axis.y;
        m.m21 = 0 + temp.z * axis.y - s * axis.x;
        m.m22 = c + temp.z * axis.z;
        return m;
    }

    public static Matrix4 RotateX(float angle)
    {
        return Rotate(angle, Vector3.Right);
    }

    public static Matrix4 RotateY(float angle)
    {
        return Rotate(angle, Vector3.Up);
    }

    public static Matrix4 RotateZ(float angle)
    {
        return Rotate(angle, Vector3.Back);
    }

    public static Matrix4 Scale(float x, float y, float z)
    {
        Matrix4 m = Identity;
        m.m00 = x;
        m.m11 = y;
        m.m22 = z;
        return m;
    }

    public static Matrix4 Scale(Vector3 v) => Scale(v.x, v.y, v.z);

    public static Matrix4 Scale(float s) => Scale(s, s, s);

    public static Matrix4 Translate(float x, float y, float z)
    {
        Matrix4 m = Identity;
        m.m30 = x;
        m.m31 = y;
        m.m32 = z;
        return m;
    }

    public static Matrix4 Translate(Vector3 v) => Translate(v.x, v.y, v.z);
    #endregion
}
#endregion