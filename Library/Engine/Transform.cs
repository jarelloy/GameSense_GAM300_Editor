using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transform : Component
{
    private bool isGlobalTransform;

    public Transform() : base()
    {
        isGlobalTransform = false;
    }

    public Transform(bool isGlobal)
    {
        isGlobalTransform = isGlobal;
    }

    public Transform globalTransform
    {
        get
        {
            Transform trans = new Transform(true);
            trans.entity = this.entity;
            return trans;
        }
    }

    public Vector3 position
    {
        get
        {
            InternalCalls.Transform_GetPosition(entity, out Vector3 result, isGlobalTransform);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetPosition(entity, ref value, isGlobalTransform);
        }
    }

    public Vector3 rotation
    {
        get
        {
            InternalCalls.Transform_GetRotation(entity, out Vector3 result, isGlobalTransform);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetRotation(entity, ref value, isGlobalTransform);
        }
    }

    public Vector3 scale
    {
        get
        {
            InternalCalls.Transform_GetScale(entity, out Vector3 result, isGlobalTransform);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetScale(entity, ref value, isGlobalTransform);
        }
    }

    /*public string Layer
    {
        get
        {
            return GetTransformZDepth_Native(entity);
        }

        set
        {
            SetTransformZDepth_Native(entity, value);
        }
    }*/

    public void Translate(Vector3 translation)
    {
        InternalCalls.Transform_Translate(entity, ref translation);
    }

    public void Rotate(Vector3 rotation)
    {
        InternalCalls.Transform_Rotate(entity, ref rotation);
    }

    public void ScaleUp(Vector3 scale)
    {
        InternalCalls.Transform_ScaleUp(entity, ref scale);
    }
}
