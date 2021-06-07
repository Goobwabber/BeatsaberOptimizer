using BeatsaberOptimizer.HarmonyPatches;
using BeatsaberOptimizer.Objects;
using IPA.Utilities;
using UnityEngine;
using Zenject;

namespace BeatsaberOptimizer.Installers
{
    class OptimizationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PlayerTransforms playerTransforms = Container.Resolve<PlayerTransforms>();
            Transform headTransform = playerTransforms.GetField<Transform, PlayerTransforms>("_headTransform");

            GameObject detectorObject = new GameObject();
            detectorObject.transform.SetParent(headTransform);
            detectorObject.layer = 9;

            ObstacleDetector obstacleDetector = Container.InstantiateComponent<ObstacleDetector>(detectorObject);
            ObstaclePatch.obstacleDetector = obstacleDetector;

            //Plugin.Log?.Info($"head layer: {headTransform.gameObject.layer}");
        }
    }
}
