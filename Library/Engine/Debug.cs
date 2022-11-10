using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class Debug
{
    public static void Log(string message)
    {
        InternalCalls.Log(message);
    }

    /*[MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DrawPoint(ref Vector3 p0, float size, ref Vector3 color, bool isUI = false);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DrawLine(ref Vector3 p0, ref Vector3 p1, float width, ref Vector3 color, bool isUI = false);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DrawCircle(ref Vector3 p0, float radius, ref Vector3 color, bool isUI = false);*/
}
