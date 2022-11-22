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
}
