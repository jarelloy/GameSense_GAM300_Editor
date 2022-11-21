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
}
