using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mathf : Component
{
    //Timer has to be between 0-1, 0 is start, 1 is end
    public static float Lerp(float startValue, float endValue, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);
        return startValue + (endValue - startValue) * timer;
    }

    public static int Lerp(int startValue, int endValue, float timer)
    {
        timer = Math.Min(timer, 1f);
        timer = Math.Max(timer, 0f);
        return (int)(startValue + (endValue - startValue) * timer);
    }
}
