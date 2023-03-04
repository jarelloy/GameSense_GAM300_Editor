using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class Time
{
    public static float deltaTime
    {
        get
        {
            return InternalCalls.Time_GetDeltaTime();
        }
    }
    public static float fixedDeltaTime
    {
        get
        {
            return InternalCalls.Time_GetFixedDeltaTime();
        }
    }
    public static float unscaledDeltaTime
    {
        get
        {
            return InternalCalls.Time_GetUnscaledDeltaTime();
        }
    }
    public static float timeScale
    {
        get
        {
            return InternalCalls.Time_GetTimeScale();
        }
        set
        {
            InternalCalls.Time_SetTimeScale(value);
        }
    }
    public static int fps
    {
        get
        {
            return InternalCalls.Time_GetFPS();
        }
    }
    public static float gameTime
    {
        get
        {
            return InternalCalls.Time_GetGameTime();
        }
    }
    public static long currentTime
    {
        get
        {
            return InternalCalls.Time_GetCurrentTime();
        }
    }

    public static void Pause()
    {
        InternalCalls.PauseDT();
    }

    public static void Unpause()
    {
        InternalCalls.UnPauseDT();
    }

    public static bool IsPaused()
    {
        return InternalCalls.IsDTPaused();
    }
}
