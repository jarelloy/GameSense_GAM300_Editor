using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CapsuleCollider : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.CapsuleCollider_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.CapsuleCollider_EnableDisable(entity, index, value);
        }
    }

    public float height
    {
        get
        {
            return InternalCalls.CapsuleCollider_GetHalfHeights(entity, index);
        }
        set
        {
            InternalCalls.CapsuleCollider_SetHalfHeights(entity, index, value);
        }
    }

    public float radius
    {
        get
        {
            return InternalCalls.CapsuleCollider_GetRadius(entity, index);
        }
        set
        {
            InternalCalls.CapsuleCollider_SetRadius(entity, index, value);
        }
    }

    public Vector3 offset
    {
        get
        {
            InternalCalls.CapsuleCollider_GetOffset(entity, index, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.CapsuleCollider_SetOffset(entity, index, ref value);
        }
    }
}
