using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using System;
using System.Threading.Tasks;
using IPALogger = IPA.Logging.Logger;
using System.Net.Http;
using BeatsaberOptimizer.HarmonyPatches;
using SiraUtil.Zenject;
using BeatsaberOptimizer.Installers;
using Zenject;

namespace BeatsaberOptimizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static readonly string HarmonyId = "com.github.Goobwabber.BeatsaberOptimizer";

        internal static Plugin Instance { get; private set; } = null!;
        internal static PluginMetadata PluginMetadata = null!;
        internal static IPALogger Log { get; private set; } = null!;

        internal static HttpClient HttpClient { get; private set; } = null!;
        internal static Harmony? _harmony;
        internal static Harmony Harmony
        {
            get
            {
                return _harmony ??= new Harmony(HarmonyId);
            }
        }

        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector, PluginMetadata pluginMetadata)
        {
            Instance = this;
            PluginMetadata = pluginMetadata;
            Log = logger;

            zenjector.OnGame<OptimizationInstaller>();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            HarmonyManager.ApplyDefaultPatches();
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }
    }
}
