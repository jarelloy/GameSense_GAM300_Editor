using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UIImage : Component
{
    public UIImage() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.UIImage_GetEnabled(entity);
        }

        set
        {
            InternalCalls.UIImage_SetEnabled(entity, value);
        }
    }

    public Vector4 color
    {
        get
        {
            InternalCalls.UIImage_GetColor(entity, out Vector4 result);
            return result;
        }

        set
        {
            InternalCalls.UIImage_SetColor(entity, ref value);
        }
    }
}
