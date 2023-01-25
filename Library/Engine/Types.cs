using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


[StructLayout(LayoutKind.Sequential)]
public struct ComponentBase
{
    public bool isDirty;

    public ComponentBase(bool dirty = true)
    {
        isDirty = dirty;
    }
}

public enum LeftAlignment
{
    LEFT,
	CENTER,
	RIGHT
};

public enum SOUND_GROUP
{
    BGM = 0,
    SFX,
    MASTER
};
    
public enum EQ_GROUP
{
    NORMAL = 0,
    LOW_PASS_FILTER = 1,
    ECHO = 2,
    DISTORTION = 3
};
