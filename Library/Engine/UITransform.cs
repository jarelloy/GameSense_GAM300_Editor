using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UITransform : Component
{
    private bool isGlobalUITransform;

    public UITransform() : base()
    {
        isGlobalUITransform = false;
    }

    public UITransform(bool isGlobal)
    {
        isGlobalUITransform = isGlobal;
    }

    public UITransform globalUITransform
    {
        get
        {
            UITransform trans = new UITransform(true);
            trans.entity = this.entity;
            return trans;
        }
    }

    public Vector3 position
    {
        get
        {
            InternalCalls.UITransform_GetPosition(entity, out Vector3 result, isGlobalUITransform);
            return result;
        }

        set
        {
            InternalCalls.UITransform_SetPosition(entity, ref value, isGlobalUITransform);
        }
    }

    public Vector3 rotation
    {
        get
        {
            InternalCalls.UITransform_GetRotation(entity, out Vector3 result, isGlobalUITransform);
            return result;
        }

        set
        {
            InternalCalls.UITransform_SetRotation(entity, ref value, isGlobalUITransform);
        }
    }

    public Vector3 scale
    {
        get
        {
            InternalCalls.UITransform_GetScale(entity, out Vector3 result, isGlobalUITransform);
            return result;
        }

        set
        {
            InternalCalls.UITransform_SetScale(entity, ref value, isGlobalUITransform);
        }
    }

    public void Translate(Vector3 translation)
    {
        InternalCalls.UITransform_Translate(entity, ref translation);
    }

    public void Rotate(Vector3 rotation)
    {
        InternalCalls.UITransform_Rotate(entity, ref rotation);
    }

    public void ScaleUp(Vector3 scale)
    {
        InternalCalls.UITransform_ScaleUp(entity, ref scale);
    }
}
