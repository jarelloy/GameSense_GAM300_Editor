using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SphereCollider : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.SphereCollider_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.SphereCollider_EnableDisable(entity, index, value);
        }
    }

    public float radius
    {
        get
        {
            return InternalCalls.SphereCollider_GetRadius(entity, index);
        }
        set
        {
            InternalCalls.SphereCollider_SetRadius(entity, index, value);
        }
    }

    public Vector3 offset
    {
        get
        {
            InternalCalls.SphereCollider_GetOffset(entity, index, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.SphereCollider_SetOffset(entity, index, ref value);
        }
    }

    public float frictionCoeff
    {
        get
        {
            return InternalCalls.SphereCollider_GetFriction(entity, index);
        }
        set
        {
            InternalCalls.SphereCollider_SetFriction(entity, index, value);
        }
    }
}
