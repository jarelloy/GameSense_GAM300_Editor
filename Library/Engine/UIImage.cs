using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UIImage : Component
{
    public UIImage() : base()
    {
    }

    public bool enabled
    {
        get
        {
            return InternalCalls.UIImage_GetEnabled(entity);
        }

        set
        {
            InternalCalls.UIImage_SetEnabled(entity, value);
        }
    }

    public float width
    {
        get
        {
            return InternalCalls.UIImage_GetWidth(entity);
        }
        
        set
        {
            InternalCalls.UIImage_SetWidth(entity, value);
        }
    }

    public float height
    {
        get
        {
            return InternalCalls.UIImage_GetHeight(entity);
        }
        
        set
        {
            InternalCalls.UIImage_SetHeight(entity, value);
        }
    }

    public Vector4 color
    {
        get
        {
            InternalCalls.UIImage_GetColor(entity, out Vector4 result);
            return result;
        }

        set
        {
            InternalCalls.UIImage_SetColor(entity, ref value);
        }
    }

    public Vector2 remapUVX
    {
        get
        {
            InternalCalls.UIImage_GetRemapUVX(entity, out Vector2 result);
            return result;
        }
        set
        {
            InternalCalls.UIImage_SetRemapUVX(entity, ref value);
        }
    }

    public Vector2 remapUVY
    {
        get
        {
            InternalCalls.UIImage_GetRemapUVY(entity, out Vector2 result);
            return result;
        }
        set
        {
            InternalCalls.UIImage_SetRemapUVY(entity, ref value);
        }
    }

    public int currentFrame
    {
        get
        {
            return InternalCalls.UIImage_GetCurrentFrame(entity);
        }
        
        set
        {
            InternalCalls.UIImage_SetCurrentFrame(entity, value);
        }
    }

    public int startFrame
    {
        get
        {
            return InternalCalls.UIImage_GetStartFrame(entity);
        }
        
        set
        {
            InternalCalls.UIImage_SetStartFrame(entity, value);
        }
    }

    public int endFrame
    {
        get
        {
            return InternalCalls.UIImage_GetEndFrame(entity);
        }
        
        set
        {
            InternalCalls.UIImage_SetEndFrame(entity, value);
        }
    }

    public bool looping
    {
        get
        {
            return InternalCalls.UIImage_GetLooping(entity);
        }

        set
        {
            InternalCalls.UIImage_SetLooping(entity, value);
        }
    }

    public int FPS
    {
        get
        {
            return InternalCalls.UIImage_GetFPS(entity);
        }

        set
        {
            InternalCalls.UIImage_SetFPS(entity, value);
        }
    }

    public bool reverseAnim
    {
        get
        {
            return InternalCalls.UIImage_GetReverseAnim(entity);
        }

        set
        {
            InternalCalls.UIImage_SetReverseAnim(entity, value);
        }
    }

    public void PlayAnim(bool looping, int startFrame, int endFrame, int currentFrame = -1)
    {
        currentFrame = currentFrame < 0 ? startFrame : currentFrame;
        InternalCalls.UIImage_PlayAnim(entity, looping, startFrame, endFrame, currentFrame);
    }

    public void StopAnim()
    {
        InternalCalls.UIImage_StopAnim(entity);
    }

    public bool IsAnimPlaying()
    {
        return InternalCalls.UIImage_IsAnimPlaying(entity);
    }
}
