using BeatsaberOptimizer.Installers;
using HarmonyLib;
using IPA;
using IPA.Loader;
using SiraUtil.Zenject;
using Conf = IPA.Config.Config;
using IPALogger = IPA.Logging.Logger;

namespace BeatsaberOptimizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    class Plugin
    {
        private readonly Harmony _harmony;
        private readonly PluginMetadata _metadata;
        public const string ID = "com.goobwabber.beatsaberoptimizer";

        [Init]
        public Plugin(IPALogger logger, Conf conf, PluginMetadata pluginMetadata, Zenjector zenjector)
        {
            _harmony = new Harmony(ID);
            _metadata = pluginMetadata;

            zenjector.UseMetadataBinder<Plugin>();
            zenjector.UseLogger(logger);
            zenjector.UseHttpService();
            zenjector.UseSiraSync(SiraUtil.Web.SiraSync.SiraSyncServiceType.GitHub, "Goobwabber", "BeatsaberOptimizer");
            zenjector.Install<OptimizerGameInstaller>(Location.Player);
        }

        [OnEnable]
        public void OnEnable()
        {
            _harmony.PatchAll(_metadata.Assembly);
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmony.UnpatchAll(ID);
        }
    }
}
