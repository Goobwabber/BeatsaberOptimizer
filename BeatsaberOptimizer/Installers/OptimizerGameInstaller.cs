using BeatsaberOptimizer.Objects;
using BeatsaberOptimizer.Patchers;
using Zenject;

namespace BeatsaberOptimizer.Installers
{
    class OptimizerGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObstacleDetector>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesAndSelfTo<ObstacleInteractionPatcher>().AsSingle();
        }
    }
}
