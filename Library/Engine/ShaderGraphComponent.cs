using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShaderGraphComponent : Component
{
    public ShaderGraphComponent() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.ShaderGraphComponent_GetEnabled(entity, index);
        }

        set
        {
            InternalCalls.ShaderGraphComponent_SetEnabled(entity, index, value);
        }
    }

    public void SetOverwriteParameter(string parameter_name, bool overwrite)
    {
        InternalCalls.ShaderGraphComponent_SetOverwriteParameter(entity, index, parameter_name, overwrite);
    }

    public void SetParameterValueFloat(string parameter_name, float value)
    {
        InternalCalls.ShaderGraphComponent_SetParameterValueFloat(entity, index, parameter_name, value);
    }

    public void SetParameterValueVec2(string parameter_name, Vector2 value)
    {
        InternalCalls.ShaderGraphComponent_SetParameterValueVec2(entity, index, parameter_name, ref value);
    }

    public void SetParameterValueVec3(string parameter_name, Vector3 value)
    {
        InternalCalls.ShaderGraphComponent_SetParameterValueVec3(entity, index, parameter_name, ref value);
    }

    public void SetParameterValueVec4(string parameter_name, Vector4 value)
    {
        InternalCalls.ShaderGraphComponent_SetParameterValueVec4(entity, index, parameter_name, ref value);
    }

    public float GetParameterValueFloat(string parameter_name)
    {
        return InternalCalls.ShaderGraphComponent_GetParameterValueFloat(entity, index, parameter_name);
    }

    public Vector2 GetParameterValueVec2(string parameter_name)
    {
        InternalCalls.ShaderGraphComponent_GetParameterValueVec2(entity, index, parameter_name, out Vector2 value);
        return value;
    }

    public Vector3 GetParameterValueVec3(string parameter_name)
    {
        InternalCalls.ShaderGraphComponent_GetParameterValueVec3(entity, index, parameter_name, out Vector3 value);
        return value;
    }

    public Vector4 GetParameterValueVec4(string parameter_name)
    {
        InternalCalls.ShaderGraphComponent_GetParameterValueVec4(entity, index, parameter_name, out Vector4 value);
        return value;
    }
}
