using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class KeyCode
{
    public const char KEY_ENTER = (char)0x0D;
    public const char KEY_TAB = (char)0x09;
    public const char KEY_SHIFT = (char)0x10;
    public const char KEY_CONTROL = (char)0x11;
    public const char KEY_ALT = (char)0x12;
    public const char KEY_CAPS = (char)0x14;
    public const char KEY_ESCAPE = (char)0x1B;
    public const char KEY_SPACE = (char)0x20;
    public const char KEY_LEFT = (char)0x25;
    public const char KEY_UP = (char)0x26;
    public const char KEY_RIGHT = (char)0x27;
    public const char KEY_DOWN = (char)0x28;
    public const char KEY_DELETE = (char)0x2E;
    public const char KEY_F1 = (char)0x70;
    public const char KEY_F2 = (char)0x71;
    public const char KEY_F3 = (char)0x72;
    public const char KEY_F4 = (char)0x73;
    public const char KEY_F5 = (char)0x74;
    public const char KEY_F6 = (char)0x75;
    public const char KEY_F7 = (char)0x76;
    public const char KEY_F8 = (char)0x77;
    public const char KEY_F9 = (char)0x78;
    public const char KEY_F10 = (char)0x79;
    public const char KEY_F11 = (char)0x7A;
    public const char KEY_F12 = (char)0x7B;
    public const char KEY_F13 = (char)0x7C;
    public const char KEY_F14 = (char)0x7D;
    public const char KEY_F15 = (char)0x7E;
    public const char KEY_F16 = (char)0x7F;
    public const char KEY_F17 = (char)0x80;
    public const char KEY_F18 = (char)0x81;
    public const char KEY_F19 = (char)0x82;
    public const char KEY_F20 = (char)0x83;
    public const char KEY_F21 = (char)0x84;
    public const char KEY_F22 = (char)0x85;
    public const char KEY_F23 = (char)0x86;
    public const char KEY_F24 = (char)0x87;
}

// keyboard characters are recognized only in CAPITAL form
public static class Input
{
    public static Vector2Int mousePosition
    {
        get
        {
            InternalCalls.Input_GetMousePosition(out Vector2Int result);
            return result;
        }
    }

    public static Vector2Int mouseDelta
    {
        get
        {
            return new Vector2Int(InternalCalls.Input_GetMouseXDelta(), InternalCalls.Input_GetMouseYDelta());
        }
    }

    public static int mouseScrollDelta
    {
        get
        {
            return InternalCalls.Input_GetMouseWheelDelta();
        }
    }

    public static int GetMouseX()
    {
        return InternalCalls.Input_GetMouseX();
    }

    public static int GetMouseY()
    {
        return InternalCalls.Input_GetMouseY();
    }

    public static int GetMouseXDelta()
    {
        return InternalCalls.Input_GetMouseXDelta();
    }

    public static int GetMouseYDelta()
    {
        return InternalCalls.Input_GetMouseYDelta();
    }

    public static bool GetMouseButtonTriggered(int key)
    {
        switch (key)
        {
            case 0: return InternalCalls.Input_GetMouseLButtonTriggered();
            case 1: return InternalCalls.Input_GetMouseRButtonTriggered();
            case 2: return InternalCalls.Input_GetMouseMButtonTriggered();
        }
        return false;
    }

    public static bool GetMouseButtonDown(int key)
    {
        switch (key)
        {
            case 0: return InternalCalls.Input_GetMouseLButton();
            case 1: return InternalCalls.Input_GetMouseRButton();
            case 2: return InternalCalls.Input_GetMouseMButton();
        }
        return false;
    }

    public static bool IsKeyDown(char key)
    {
        return InternalCalls.IsKeyDown(key);
    }
    public static bool IsKeyTriggered(char key)
    {
        return InternalCalls.IsKeyTriggered(key);
    }
    public static bool AnyKeyTriggered()
    {
        return InternalCalls.AnyKeyTriggered();
    }
}
