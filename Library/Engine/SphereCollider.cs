﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SphereCollider : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.SphereCollider_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.SphereCollider_EnableDisable(entity, index, value);
        }
    }
}
