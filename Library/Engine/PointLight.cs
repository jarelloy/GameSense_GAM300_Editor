using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PointLight : Component
{
    public PointLight() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.PointLight_GetEnabled(entity);
        }

        set
        {
            InternalCalls.PointLight_SetEnabled(entity, value);
        }
    }

    public float intensity
    {
        get
        {
            return InternalCalls.PointLight_GetIntensity(entity);
        }

        set
        {
            InternalCalls.PointLight_SetIntensity(entity, value);
        }
    }

    public float radius
    {
        get
        {
            return InternalCalls.PointLight_GetRadius(entity);
        }

        set
        {
            InternalCalls.PointLight_SetRadius(entity, value);
        }
    }

    public Vector3 color
    {
        get
        {
            InternalCalls.PointLight_GetColor(entity, out Vector3 result);
            return result;
        }

        set
        {
            InternalCalls.PointLight_SetColor(entity, ref value);
        }
    }
}
