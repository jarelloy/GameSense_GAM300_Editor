using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class AudioComponent : Component
{
    #region basic
    public bool enabled
    {
        get
        {
            return InternalCalls.Audio_GetEnabled(entity, index);
        }
        set
        {
            InternalCalls.Audio_EnableDisable(entity, index, value);
        }
    }

    public float volume
    {
        get
        {
            return InternalCalls.Audio_GetVolume(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetVolume(entity, index, value);
        }
    }

    public bool loop
    {
        get
        {
            return InternalCalls.Audio_GetLoop(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetLoop(entity, index, value);
        }
    }

    public SOUND_GROUP sg
    {
        get
        {
            return (SOUND_GROUP)InternalCalls.Audio_GetSoundGroup(entity);
        }
        set
        {
            InternalCalls.Audio_SetSoundGroup(entity, (int)value);
        }
    }
    #endregion

    #region stereo
    public bool stereo
    {
        get
        {
            return InternalCalls.Audio_GetStereo(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetStereo(entity, index, value);
        }
    }

    public float stereo_mindistance
    {
        get
        {
            return InternalCalls.Audio_GetMinDistance(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetMinDistance(entity, index, value);
        }
    }

    public float stereo_maxdistance
    {
        get
        {
            return InternalCalls.Audio_GetMaxDistance(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetMaxDistance(entity, index, value);
        }
    }
    #endregion

    #region fade
    public bool fadeIn
    {
        get
        {
            return InternalCalls.Audio_GetFadeIn(entity, index);
        }

        set
        {
            InternalCalls.Audio_SetFadeIn(entity, index, value);
        }
    }

    public bool fadeOut
    {
        get
        {
            return InternalCalls.Audio_GetFadeOut(entity, index);
        }

        set
        {
            InternalCalls.Audio_SetFadeOut(entity, index, value);
        }
    }

    public float fadeInTimer
    {
        get
        {
            return InternalCalls.Audio_GetFadeInTimer(entity, index);
        }

        set
        {
            InternalCalls.Audio_SetFadeInTimer(entity, index, value);
        }
    }

    public float fadeOutTimer
    {
        get
        {
            return InternalCalls.Audio_GetFadeOutTimer(entity, index);
        }

        set
        {
            InternalCalls.Audio_SetFadeOutTimer(entity, index, value);
        }
    }
    #endregion 

    #region effects
    public bool lowpassfilter
    {
        get
        {
            return InternalCalls.Audio_GetLPF(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetLPF(entity, index, value);
        }
    }

    public float LPFcutoff
    {
        get
        {
            return InternalCalls.Audio_GetLPFCutoff(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetLPFCutoff(entity, index, value);
        }
    }

    public float LPFResonance
    {
        get
        {
            return InternalCalls.Audio_GetLPFResonance(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetLPFResonance(entity, index, value);
        }
    }

    public bool reverb
    {
        get
        {
            return InternalCalls.Audio_GetReverb(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetReverb(entity, index, value);
        }
    }

    public float reverbDelay
    {
        get
        {
            return InternalCalls.Audio_GetReverbDelay(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetReverbDelay(entity, index, value);
        }
    }

    public float reverbFeedback
    {
        get
        {
            return InternalCalls.Audio_GetReverbFeedback(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetReverbFeedback(entity, index, value);
        }
    }

    public float reverbWetLevel
    {
        get
        {
            return InternalCalls.Audio_GetReverbWetLevel(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetReverbWetLevel(entity, index, value);
        }
    }

    public float reverbDryLevel
    {
        get
        {
            return InternalCalls.Audio_GetReverbDryLevel(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetReverbDryLevel(entity, index, value);
        }
    }

    public bool distortion
    {
        get
        {
            return InternalCalls.Audio_GetDistortion(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetDistortion(entity, index, value);
        }
    }

    public float distortionLevel
    {
        get
        {
            return InternalCalls.Audio_GetDistortionLevel(entity, index);
        }
        set
        {
            InternalCalls.Audio_SetDistortionLevel(entity, index, value);
        }
    }
    #endregion

    // TODO more component stuff getter setter

    public void PlayAudio()
    {
        InternalCalls.Audio_Play(entity, index);
    }

    public void StopAudio()
    {
        InternalCalls.Audio_Stop(entity, index);
    }

    public void MuteAudio()
    {
        InternalCalls.Audio_Mute(entity, index);
    }

    public void UnmuteAudio()
    {
        InternalCalls.Audio_Unmute(entity, index);
    }

    public void PauseAudio()
    {
        InternalCalls.Audio_Pause(entity, index);
    }

    public void UnpauseAudio()
    {
        InternalCalls.Audio_Unpause(entity, index);
    }

    public bool IsPlayingAudio()
    {
        return InternalCalls.Audio_IsPlaying(entity, index);
    }

    public static void SetSoundGroupVolume(SOUND_GROUP sg, float value)
    {

        InternalCalls.Audio_SetSoundGroupVolume((int)sg, value);
    }

    public static float GetSoundGroupVolume(SOUND_GROUP sg)
    {
        return InternalCalls.Audio_GetSoundGroupVolume((int)sg);
    }
}
