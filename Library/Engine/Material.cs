using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MaterialAsset
{
    public readonly ulong ID;
    public MaterialAsset(ulong material_id)
    {
        ID = material_id;
    }

    public Vector4 diffuseTint
    {
        get
        {
            InternalCalls.MaterialObject_GetDiffuseTint(ID, out Vector4 result);
            return result;
        }
        set
        {
            InternalCalls.MaterialObject_SetDiffuseTint(ID, ref value);
        }
    }

    public float glossiness
    {
        get
        {
            return InternalCalls.MaterialObject_GetGlossiness(ID);
        }
        set
        {
            InternalCalls.MaterialObject_SetGlossiness(ID, value);
        }
    }

    public float specular
    {
        get
        {
            return InternalCalls.MaterialObject_GetSpecular(ID);
        }
        set
        {
            InternalCalls.MaterialObject_SetSpecular(ID, value);
        }
    }

    public bool emissionEnabled
    {
        get
        {
            return InternalCalls.MaterialObject_GetEmissionEnabled(ID);
        }
        set
        {
            InternalCalls.MaterialObject_SetEmissionEnabled(ID, value);
        }
    }

    public Vector3 emissionColor
    {
        get
        {
            InternalCalls.MaterialObject_GetEmissionColor(ID, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.MaterialObject_SetEmissionColor(ID, ref value);
        }
    }

    public float emissionintensity
    {
        get
        {
            return InternalCalls.MaterialObject_GetEmissionIntensity(ID);
        }
        set
        {
            InternalCalls.MaterialObject_SetEmissionIntensity(ID, value);
        }
    }

    TextureAsset GetTexture(int texture_type)
    {
        ulong texture_id = InternalCalls.MaterialObject_GetTexture(ID, texture_type);
        return new TextureAsset(texture_id);
    }

    void SetTexture(int texture_type, ref TextureAsset texture)
    {
        InternalCalls.MaterialObject_SetTexture(ID, texture_type, texture.ID);
    }
}

public class Material : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.Material_GetEnabled(entity);
        }
        set
        {
            InternalCalls.Material_EnableDisable(entity, value);
        }
    }

    public MaterialAsset materialAsset
    {
        get
        {
            ulong material_id = InternalCalls.Material_GetMaterialAsset(entity);
            return new MaterialAsset(material_id);
        }
        set
        {
            InternalCalls.Material_SetMaterialAsset(entity, value.ID);
        }
    }
    
    public bool overwriteMaterial
    {
        get
        {
            return InternalCalls.Material_GetOverwriteMaterialReference(entity);
        }
        set
        {
            InternalCalls.Material_SetOverwriteMaterialReference(entity, value);
        }
    }

    public Vector4 diffuseTint
    {
        get
        {
            InternalCalls.Material_GetDiffuseTint(entity, out Vector4 result);
            return result;
        }
        set
        {
            InternalCalls.Material_SetDiffuseTint(entity, ref value);
        }
    }

    public float glossiness
    {
        get
        {
            return InternalCalls.Material_GetGlossiness(entity);
        }
        set
        {
            InternalCalls.Material_SetGlossiness(entity, value);
        }
    }

    public float specular
    {
        get
        {
            return InternalCalls.Material_GetSpecular(entity);
        }
        set
        {
            InternalCalls.Material_SetSpecular(entity, value);
        }
    }

    public bool emissionEnabled
    {
        get
        {
            return InternalCalls.Material_GetEmissionEnabled(entity);
        }
        set
        {
            InternalCalls.Material_SetEmissionEnabled(entity, value);
        }
    }

    public Vector3 emissionColor
    {
        get
        {
            InternalCalls.Material_GetEmissionColor(entity, out Vector3 result);
            return result;
        }
        set
        {
            InternalCalls.Material_SetEmissionColor(entity, ref value);
        }
    }

    public float emissionintensity
    {
        get
        {
            return InternalCalls.Material_GetEmissionIntensity(entity);
        }
        set
        {
            InternalCalls.Material_SetEmissionIntensity(entity, value);
        }
    }

    TextureAsset GetTexture(int texture_type)
    {
        ulong texture_id = InternalCalls.Material_GetTexture(entity, texture_type);
        return new TextureAsset(texture_id);
    }

    void SetTexture(int texture_type, ref TextureAsset texture)
    {
        InternalCalls.Material_SetTexture(entity, texture_type, texture.ID);
    }
}
