using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneManager
{
    public static string GetCurrentSceneName()
    {
        return InternalCalls.SceneManager_GetCurrentSceneName();
    }

    public static float GetPreloadingSceneLoadPercentage(string sceneName)
    {
        return InternalCalls.SceneManager_GetPreloadingSceneLoadPercentage(sceneName);
    }

    public static float GetPreloadingSceneInitPercentage(string sceneName)
    {
        return InternalCalls.SceneManager_GetPreloadingSceneInitPercentage(sceneName);
    }

    public static bool IsPreloadingSceneCompleted(string sceneName)
    {
        return InternalCalls.SceneManager_GetPreloadingSceneCompleted(sceneName);
    }

    public static void QuitGame()
    {
        InternalCalls.SceneManager_QuitGame();
    }

    public static void ChangeScene(string sceneName)
    {
        InternalCalls.SceneManager_ChangeScene(sceneName);
    }

    public static void PreloadScene(string sceneName, uint sleepDelay = 100)
    {
        InternalCalls.SceneManager_PreloadScene(sceneName, sleepDelay);
    }
}
