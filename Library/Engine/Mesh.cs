using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mesh : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.Mesh_GetEnabled(entity);
        }
        set
        {
            InternalCalls.Mesh_EnableDisable(entity, value);
        }
    }
}
