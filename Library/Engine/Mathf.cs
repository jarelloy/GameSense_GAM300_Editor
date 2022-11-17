using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mathf
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

    // maxSpeed and deltaTime params can be ignored; they default to positive infinity and Time.deltaTime respectively if not set
    public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = float.PositiveInfinity, float deltaTime = 0.0f)
    {
        if (deltaTime.Equals(0.0f))
            deltaTime = Time.deltaTime;

        // Based on Game Programming Gems 4 Chapter 1.10
        smoothTime = MathF.Max(0.0001F, smoothTime);
        float omega = 2F / smoothTime;

        float x = omega * deltaTime;
        float exp = 1F / (1F + x + 0.48F * x * x + 0.235F * x * x * x);
        float change = current - target;
        float originalTo = target;

        // Clamp maximum speed
        float maxChange = maxSpeed * smoothTime;
        change = Math.Clamp(change, -maxChange, maxChange);
        target = current - change;

        float temp = (currentVelocity + omega * change) * deltaTime;
        currentVelocity = (currentVelocity - omega * temp) * exp;
        float output = target + (change + temp) * exp;

        // Prevent overshooting
        if (originalTo - current > 0.0F == output > originalTo)
        {
            output = originalTo;
            currentVelocity = (output - originalTo) / deltaTime;
        }

        return output;
    }
}
