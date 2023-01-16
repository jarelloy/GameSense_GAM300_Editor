using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class GameObject
{
    const ulong NIL = 0;
    public readonly ulong ID = 0;
    public GameObject(ulong e)
    {
        ID = e;
    }

    public GameObject Parent
    {
        get
        {
            ulong parentID = InternalCalls.GetEntityParentID_Native(ID);
            if (parentID != 0)
            {
                return new GameObject(parentID);
            }
            else
            {
                return null;
            }
        }
    }

    public GameObject GetChild(int index)
    {
        ulong childID = InternalCalls.GetEntityChildID_Native(ID, index);
        if (childID != 0)
        {
            return new GameObject(childID);
        }
        else
        {
            return null;
        }
    }

    public string Name
    {
        get
        {
            return InternalCalls.GetEntityNameByID_Native(ID);
        }
    }

    public void EnableEntity(ulong ent = NIL)
    {
        if (ent == NIL)
            InternalCalls.EnableDisable_Native(ID, true);
        else
            InternalCalls.EnableDisable_Native(ent, true);
    }

    public void DisableEntity(ulong ent = NIL)
    {
        if (ent == NIL)
            InternalCalls.EnableDisable_Native(ID, false);
        else
            InternalCalls.EnableDisable_Native(ent, false);
    }

    /**
        * Checks if Component Exists in Current Entity
        * 
        * 
        * \return bool
        */
    public bool HasComponent<T>() where T : Component, new()
    {
        return InternalCalls.HasComponent_Native(ID, typeof(T));
    }
    /**
        * Checks if Component Exists in An Entity
        * 
        * \param ent
        * \return smth
        */
    public bool HasComponent<T>(ulong ent) where T : Component, new()
    {
        return InternalCalls.HasComponent_Native(ent, typeof(T));
    }

    public int GetComponentsCount<T>() where T : Component, new()
    {
        return InternalCalls.GetComponentsCount_Native(ID, typeof(T));
    }

    public T AddComponent<T>() where T : Component, new()
    {
        if (!HasComponent<T>())
        {
            InternalCalls.AddComponent_Native(ID, typeof(T));
            T component = new T();
            component.entity = ID;

            // index of newly added component via script would have index of current count
            component.index = GetComponentsCount<T>();

            return component;
        }
        return null;
    }

    // disabling for now as im not seeing its use yet
    /*public T AddComponent<T>(ulong ent) where T : Component, new()
    {
        if (!HasComponent<T>(ent))
        {
            InternalCalls.AddComponent_Native(ent, typeof(T));
            T component = new T()
            {
                entity = ent
            };
            return component;
        }
        return null;
    }*/

    public T GetComponent<T>(int idx = 0) where T : Component, new()
    {
        if (HasComponent<T>())
        {
            // index boundary check
            if (idx >= GetComponentsCount<T>())
            {
                throw new IndexOutOfRangeException("Component index out of range!");
            }
            else
            {
                T component = new T();
                component.entity = ID;
                component.index = idx;
                return component;
            }
        }

        return null;
    }

    public bool HasScriptComponent<T>()
    {
        // send name of script to script system to check
        string scriptName = typeof(T).ToString();
        return InternalCalls.HasScriptComponent_Native(ID, scriptName);
    }

    public T GetScriptComponent<T>()
    {
        if (HasScriptComponent<T>())
        {
            // return reference of the instance of the script component
            string scriptName = typeof(T).ToString();
            object scriptObj = InternalCalls.GetScriptComponent_Native(ID, scriptName);
            return (T)scriptObj;
        }

        return default(T);
    }

    public static T GetGlobalScriptComponent<T>()
    {
        // return reference of the instance of the script component
        string scriptName = typeof(T).ToString();
        object scriptObj = InternalCalls.GetGlobalScriptComponent_Native(scriptName);
        return (T)scriptObj;
    }

    // disabling as its params are conflicting with above get component function
    /*public T GetComponent<T>(ulong ent, int idx = 0) where T : Component, new()
    {
        if (HasComponent<T>(ent))
        {
            T component = new T()
            {
                entity = ent,
                index = idx
            };
            return component;
        }
        return null;
    }*/

    public Transform transform
    {
        get
        {
            return GetComponent<Transform>();
        }
    }

    public static GameObject Instantiate(GameObject original)
    {
        ulong id = InternalCalls.CreateEntity_Native(original != null ? original.ID : 0);
        return new GameObject(id);
    }

    public static GameObject InstantiateUI(GameObject original)
    {
        ulong id = InternalCalls.CreateEntityUI_Native(original != null ? original.ID : 0);
        return new GameObject(id);
    }

    public static GameObject InstantiatePrefab(string prefab)//, bool isUI = false)
    {
        ulong id = InternalCalls.CreateEntityPrefab_Native(prefab);
        return id == 0 ? null : new GameObject(id);
    }

    public static void Destroy(GameObject obj)
    {
        InternalCalls.DestroyEntity_Native(obj.ID);
    }

    public static GameObject GetEntityIDByName(string name)
    {
        ulong id = InternalCalls.GetEntityIDByName_Native(name);
        return new GameObject(id);
    }

    public static GameObject Find(string name)
    {
        ulong id = InternalCalls.GetEntityIDByName_Native(name);
        return new GameObject(id);
    }
}