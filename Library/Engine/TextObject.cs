using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TextObject : Component
{
    public TextObject() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.TextObject_GetEnabled(entity);
        }

        set
        {
            InternalCalls.TextObject_SetEnabled(entity, value);
        }
    }

    public Vector4 color
    {
        get
        {
            InternalCalls.TextObject_GetColor(entity, out Vector4 result);
            return result;
        }

        set
        {
            InternalCalls.TextObject_SetColor(entity, ref value);
        }
    }

    public string text
    {
        get
        {
            return InternalCalls.TextObject_GetText(entity);
        }
        set
        {
            InternalCalls.TextObject_SetText(entity, value);
        }
    }
}
