using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public abstract class Component
{
    public GameObject gameObject
    {
        get
        {
            return new GameObject(entity);
        }
    }

    public ulong entity;
}
