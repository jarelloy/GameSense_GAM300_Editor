using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class Window
{
    public static int width
    {
        get
        {
            return InternalCalls.Window_GetWidth();
        }
    }
    public static int height
    {
        get
        {
            return InternalCalls.Window_GetHeight();
        }
    }
    public static bool cursorVisibility
    {
        get
        {
            return InternalCalls.Window_GetCursorVisibility();
        }
        set
        {
            InternalCalls.Window_SetCursorVisibility(value);
        }
    }
}
