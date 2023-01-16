using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TextureAssetType
{
    public const int OTHER = 0;
    public const int DIFFUSE = 1;
    public const int AMBIENT_OCCLUSION = 2;
    public const int NORMALS = 3;
    public const int SHININESS = 4; // Glossiness
    public const int METALNESS = 5; // Specular
    public const int EMISSION = 6;
}

public class TextureAsset
{
    public readonly ulong ID;
    public TextureAsset(ulong texture_id)
    {
        ID = texture_id;
    }
}