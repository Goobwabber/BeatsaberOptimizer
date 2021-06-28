using HarmonyLib;
using IPA;
using IPA.Loader;
using IPALogger = IPA.Logging.Logger;
using System.Net.Http;
using BeatsaberOptimizer.HarmonyPatches;
using SiraUtil.Zenject;
using BeatsaberOptimizer.Installers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

            zenjector.OnGame<OptimizationInstaller>().ShortCircuitForMultiplayer();
            zenjector.Register<OptimizationInstaller>().On<MultiplayerLocalActivePlayerInstaller>();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            HarmonyManager.ApplyDefaultPatches();

            //List<int> layerList = Enumerable.Range(0, 31).ToList();
            //Log?.Info($"({LayerMask.LayerToName(11)}, {LayerMask.LayerToName(0)}): {Physics.GetIgnoreLayerCollision(0, 11)}");

            //foreach (int layer in layerList)
            //{
            //    string name = LayerMask.LayerToName(layer).PadRight(26);
            //    Log?.Info($"{name}: {LayerMask.LayerToName(8).PadRight(18)} {Physics.GetIgnoreLayerCollision(layer, 8)}");
            //    Log?.Info($"{name}: {LayerMask.LayerToName(9).PadRight(18)} {Physics.GetIgnoreLayerCollision(layer, 9)}");
            //    Log?.Info($"{name}: {LayerMask.LayerToName(11).PadRight(18)} {Physics.GetIgnoreLayerCollision(layer, 11)}");
            //    Log?.Info($"{name}: {LayerMask.LayerToName(12).PadRight(18)} {Physics.GetIgnoreLayerCollision(layer, 12)}");
            //    Log?.Info($"{name}: {LayerMask.LayerToName(16).PadRight(18)} {Physics.GetIgnoreLayerCollision(layer, 16)}");
            //}
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }
    }
}
