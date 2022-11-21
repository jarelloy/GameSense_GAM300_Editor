using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParticleEngine : Component
{
    public bool enabled
    {
        get
        {
            return InternalCalls.Particle_GetEnabled(entity);
        }
        set
        {
            InternalCalls.Particle_EnableDisabled(entity, value);
        }
    }

    public void Start()
    {
        InternalCalls.Particle_Start(entity);
    }

    public void Stop()
    {
        InternalCalls.Particle_Stop(entity);
    }

    public void Restart()
    {
        InternalCalls.Particle_Restart(entity);
    }
}
