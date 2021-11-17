using BeatsaberOptimizer.Objects;
using SiraUtil.Affinity;
using System.Collections.Generic;

namespace BeatsaberOptimizer.Patchers
{
    public class ObstacleInteractionPatcher : IAffinity
    {
        private readonly ObstacleDetector _obstacleDetector;

        internal ObstacleInteractionPatcher(
            ObstacleDetector obstacleDetector)
        {
            _obstacleDetector = obstacleDetector;
        }

        [AffinityPrefix]
        [AffinityPatch(typeof(PlayerHeadAndObstacleInteraction), nameof(PlayerHeadAndObstacleInteraction.intersectingObstacles), AffinityMethodType.Getter)]
        private void GetIntersectingObstacles(ref List<ObstacleController> __result)
        {
            __result = _obstacleDetector.IntersectingObstacles;
        }
    }
}
