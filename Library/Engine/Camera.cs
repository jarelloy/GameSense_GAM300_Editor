using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Camera : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.Camera_GetEnabled(entity);
        }
        set
        {
            InternalCalls.Camera_EnableDisable(entity, value);
        }
    }

    public Vector2 viewPortSize
    {
        get
        {
            InternalCalls.Camera_GetViewPortSize(entity, out Vector2 result);
            return result;
        }
        set
        {
            InternalCalls.Camera_SetViewPortSize(entity, ref value);
        }
    }

    public Vector2 viewPortOffset
    {
        get
        {
            InternalCalls.Camera_GetViewPortOffset(entity, out Vector2 result);
            return result;
        }
        set
        {
            InternalCalls.Camera_SetViewPortOffset(entity, ref value);
        }
    }

    public float pitch
    {
        get
        {
            return InternalCalls.Camera_GetPitch(entity);
        }
        set
        {
            InternalCalls.Camera_SetPitch(entity, value);
        }
    }

    public float yaw
    {
        get
        {
            return InternalCalls.Camera_GetYaw(entity);
        }
        set
        {
            InternalCalls.Camera_SetYaw(entity, value);
        }
    }

    public float roll
    {
        get
        {
            return InternalCalls.Camera_GetRoll(entity);
        }
        set
        {
            InternalCalls.Camera_SetRoll(entity, value);
        }
    }

    public float zNear
    {
        get
        {
            return InternalCalls.Camera_GetZNear(entity);
        }
        set
        {
            InternalCalls.Camera_SetZNear(entity, value);
        }
    }

    public float zFar
    {
        get
        {
            return InternalCalls.Camera_GetZFar(entity);
        }
        set
        {
            InternalCalls.Camera_SetZFar(entity, value);
        }
    }

    public float aspectRatio
    {
        get
        {
            return InternalCalls.Camera_GetAspectRatio(entity);
        }
        set
        {
            InternalCalls.Camera_SetAspectRatio(entity, value);
        }
    }

    public float fov
    {
        get
        {
            return InternalCalls.Camera_GetFieldOfView(entity);
        }
        set
        {
            InternalCalls.Camera_SetFieldOfView(entity, value);
        }
    }

    public Vector3 forward
    {
        get
        {
            InternalCalls.Camera_GetForwardVector(entity, out Vector3 result);
            return result;
        }
    }

    public Vector3 right
    {
        get
        {
            InternalCalls.Camera_GetRightVector(entity, out Vector3 result);
            return result;
        }
    }

    public Vector3 up
    {
        get
        {
            InternalCalls.Camera_GetUpVector(entity, out Vector3 result);
            return result;
        }
    }

    public void Shake(Vector2 direction, float intensity, float fade = 1f)
    {
        InternalCalls.Camera_Shake(entity, ref direction, intensity, fade);
    }
}
