using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoxCollider : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.BoxCollider_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.BoxCollider_EnableDisable(entity, index, value);
        }
    }

    public Vector3 size
    {
        get
        {
            InternalCalls.BoxCollider_GetHalfExtents(entity, index, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.BoxCollider_SetHalfExtents(entity, index, ref value);
        }
    }

    public Vector3 offset
    {
        get
        {
            InternalCalls.BoxCollider_GetOffset(entity, index, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.BoxCollider_SetOffset(entity, index, ref value);
        }
    }

    public float frictionCoeff
    {
        get
        {
            return InternalCalls.BoxCollider_GetFriction(entity, index);
        }
        set
        {
            InternalCalls.BoxCollider_SetFriction(entity, index, value);
        }
    }
}
