using BeatsaberOptimizer.Objects;
using HarmonyLib;
using System.Collections.Generic;

namespace BeatsaberOptimizer.HarmonyPatches
{
    [HarmonyPatch(typeof(PlayerHeadAndObstacleInteraction), nameof(PlayerHeadAndObstacleInteraction.intersectingObstacles), MethodType.Getter)]
    internal class ObstaclePatch
    {
        internal static ObstacleDetector? obstacleDetector;

        static bool Prefix(ref List<ObstacleController> __result)
        {
            if (obstacleDetector != null)
            {
                __result = obstacleDetector.intersectingObstacles;
                return false;
            }
            Plugin.Log?.Warn("Obstacle Detector not found!");
            return true;
        }
    }
}
