using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transform : Component
{
    //public Transform GlobalTransform
    //{
    //    get
    //    {
    //        GetGlobalTransform_Native(entity, out Transform result);
    //        result.layer = GetTransformZDepth_Native(entity);
    //        return result;
    //    }
    //}

    public Vector3 position
    {
        get
        {
            InternalCalls.Transform_GetPosition(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetPosition(entity, ref value);
        }
    }

    public Vector3 rotation
    {
        get
        {
            InternalCalls.Transform_GetRotation(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetRotation(entity, ref value);
        }
    }

    public Vector3 scale
    {
        get
        {
            InternalCalls.Transform_GetScale(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.Transform_SetScale(entity, ref value);
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
