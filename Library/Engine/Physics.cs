using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Physics
{
    public static bool Raycast(Vector3 ray_pos, Vector3 ray_dir, float ray_length, out GameObject entity_hit, out Vector3 hit_pos, out Vector3 hit_normal)
    {
        bool hit = InternalCalls.Physics_Raycast(ref ray_pos, ref ray_dir, ray_length, out ulong entityID, out hit_pos, out hit_normal);
        entity_hit = entityID != 0 ? new GameObject(entityID) : null;
        return hit;
    }

    public static bool RaycastSingleLayer(string layername, Vector3 ray_pos, Vector3 ray_dir, float ray_length, out GameObject entity_hit, out Vector3 hit_pos, out Vector3 hit_normal)
    {
        bool hit = InternalCalls.Physics_RaycastLayers(layername, true, ref ray_pos, ref ray_dir, ray_length, out ulong entityID, out hit_pos, out hit_normal);
        entity_hit = entityID != 0 ? new GameObject(entityID) : null;
        return hit;
    }

    public static bool RaycastLayers(List<string> layernames, Vector3 ray_pos, Vector3 ray_dir, float ray_length, out GameObject entity_hit, out Vector3 hit_pos, out Vector3 hit_normal)
    {
        int i = 0;
        for (; i < layernames.Count - 1; ++i)
        {
            InternalCalls.Physics_RaycastLayers(layernames[i], false, ref ray_pos, ref ray_dir, ray_length, out ulong entityid, out hit_pos, out hit_normal);
        }
        bool hit = InternalCalls.Physics_RaycastLayers(layernames[i], true, ref ray_pos, ref ray_dir, ray_length, out ulong entityID, out hit_pos, out hit_normal);
        entity_hit = entityID != 0 ? new GameObject(entityID) : null;
        return hit;
    }

    public static Vector3 Gravity
    {
        get
        {
            InternalCalls.Physics_GetGravity(out Vector3 gravity);
            return gravity;
        }
    }
}
