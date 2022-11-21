using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MeshCollider : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.MeshCollider_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.MeshCollider_EnableDisable(entity, index, value);
        }
    }
}
