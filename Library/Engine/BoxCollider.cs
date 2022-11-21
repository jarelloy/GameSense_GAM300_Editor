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
}
