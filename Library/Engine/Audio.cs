using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class AudioComponent : Component
{

    public float volume
    {
        get
        {
            return InternalCalls.Audio_GetVolume(entity);
        }
        set
        {
            InternalCalls.Audio_SetVolume(entity, value);
        }
    }

    public bool loop
    {
        get
        {
            return InternalCalls.Audio_GetLoop(entity);
        }
        set
        {
            InternalCalls.Audio_SetLoop(entity, value);
        }
    }

    public bool stereo
    {
        get
        {
            return InternalCalls.Audio_GetStereo(entity);
        }
        set
        {
            InternalCalls.Audio_SetStereo(entity, value);
        }
    }

    public bool lowpassfilter
    {
        get
        {
            return InternalCalls.Audio_GetLPF(entity);
        }
        set
        {
            InternalCalls.Audio_SetLPF(entity, value);
        }
    }

    public float LPFcutoff
    {
        get
        {
            return InternalCalls.Audio_GetLPFCutoff(entity);
        }
        set
        {
            InternalCalls.Audio_SetLPFCutoff(entity, value);
        }
    }

    public float LPFResonance
    {
        get
        {
            return InternalCalls.Audio_GetLPFResonance(entity);
        }
        set
        {
            InternalCalls.Audio_SetLPFResonance(entity, value);
        }
    }

    public bool reverb
    {
        get
        {
            return InternalCalls.Audio_GetReverb(entity);
        }
        set
        {
            InternalCalls.Audio_SetReverb(entity, value);
        }
    }

    public float reverbDelay
    {
        get
        {
            return InternalCalls.Audio_GetReverbDelay(entity);
        }
        set
        {
            InternalCalls.Audio_SetReverbDelay(entity, value);
        }
    }

    public float reverbFeedback
    {
        get
        {
            return InternalCalls.Audio_GetReverbFeedback(entity);
        }
        set
        {
            InternalCalls.Audio_SetReverbFeedback(entity, value);
        }
    }

    public float reverbWetLevel
    {
        get
        {
            return InternalCalls.Audio_GetReverbWetLevel(entity);
        }
        set
        {
            InternalCalls.Audio_SetReverbWetLevel(entity, value);
        }
    }

    public float reverbDryLevel
    {
        get
        {
            return InternalCalls.Audio_GetReverbDryLevel(entity);
        }
        set
        {
            InternalCalls.Audio_SetReverbDryLevel(entity, value);
        }
    }

    public bool distortion
    {
        get
        {
            return InternalCalls.Audio_GetDistortion(entity);
        }
        set
        {
            InternalCalls.Audio_SetDistortion(entity, value);
        }
    }

    public float distortionLevel
    {
        get
        {
            return InternalCalls.Audio_GetDistortionLevel(entity);
        }
        set
        {
            InternalCalls.Audio_SetDistortionLevel(entity, value);
        }
    }

    // TODO more component stuff getter setter

    public void PlayAudio()
    {
        InternalCalls.Audio_Play(entity);
    }

    public void StopAudio()
    {
        InternalCalls.Audio_Stop(entity);
    }

    public void MuteAudio()
    {
        InternalCalls.Audio_Mute(entity);
    }

    public void UnmuteAudio()
    {
        InternalCalls.Audio_Unmute(entity);
    }

    public void PauseAudio()
    {
        InternalCalls.Audio_Pause(entity);
    }

    public void UnpauseAudio()
    {
        InternalCalls.Audio_Unpause(entity);
    }
}
