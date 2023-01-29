using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UICollider : Component
{
    public UICollider() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.UICollider_GetEnabled(entity);
        }

        set
        {
            InternalCalls.UICollider_SetEnabled(entity, value);
        }
    }

    public float radius
    {
        get
        {
            return InternalCalls.UICollider_GetRadius(entity);
        }

        set
        {
            InternalCalls.UICollider_SetRadius(entity, value);
        }
    }

    public Vector3 offset
    {
        get
        {
            InternalCalls.UICollider_GetOffset(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.UICollider_SetOffset(entity, ref value);
        }
    }

    public Vector3 halfExtent
    {
        get
        {
            InternalCalls.UICollider_GetHalfExtent(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.UICollider_SetHalfExtent(entity, ref value);
        }
    }
}
