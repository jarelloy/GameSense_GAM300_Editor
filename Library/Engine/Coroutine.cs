using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void TimedFunc();
class TimedFunction
{
    public TimedFunc func;
    public float timer;

    public TimedFunction(TimedFunc f, float t)
    {
        func = f;
        timer = t;
    }
}

public static class Coroutine
{
    static List<TimedFunction> timedFunctions = new List<TimedFunction>();

    private static void Update()
    {
        for (int i = timedFunctions.Count - 1; i >= 0; i--)
        {
            timedFunctions[i].timer -= Time.unscaledDeltaTime;
            if (timedFunctions[i].timer <= 0f)
            {
                timedFunctions[i].func();
                timedFunctions.RemoveAt(i);
            }
        }
    }

    public static void Execute(TimedFunc f, float delay)
    {
        timedFunctions.Add(new TimedFunction(f, delay));
    }
}
