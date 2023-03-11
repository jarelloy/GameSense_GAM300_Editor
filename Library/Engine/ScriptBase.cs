using System;
using System.Collections.Generic;
using System.Text;

public class ScriptBase
{
    public GameObject gameobject;

    public ScriptBase(ulong e)
    {
        gameobject = new GameObject(e);
    }

    void UpdateGameObject(GameObject go)
    {
        gameobject = go;
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }
}
