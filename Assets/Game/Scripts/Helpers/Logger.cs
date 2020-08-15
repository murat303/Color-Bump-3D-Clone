using ColorBump;
using UnityEngine;

public class Logger
{
    public static void Log(string message)
    {
        if (LevelManager.ins.settings.showLogs)
            Debug.Log(message);
    }

    public static void LogDistance(float DistanceLeft, float EntireDistance)
    {
        if (LevelManager.ins.settings.showDistanceLog)
            Debug.Log("Distance Left: " + DistanceLeft + " Entire Distance: " + EntireDistance);
    }
}
