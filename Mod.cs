using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using System.Linq;
using System.Reflection;
using EasterEggstravaganza.Customs.Processes;
using KitchenData;
using KitchenLib.Event;
using KitchenLib.Interfaces;
using KitchenLib.References;
using KitchenLib.Utils;
using TMPro;
using UnityEngine;

namespace EasterEggstravaganza
{
    public class Mod : BaseMod, IModSystem, IAutoRegisterAll
    {
        public const string MOD_GUID = "com.starfluxgames.eastereggstravaganza";
        public const string MOD_NAME = "Easter Eggstravaganza";
        public const string MOD_VERSION = "0.1.4";
        public const string MOD_AUTHOR = "StarFluxGames";
        public const string MOD_GAMEVERSION = ">=1.1.9";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public static readonly int LasagneTray = -2080052245;
        public static readonly int Butter = 1605072344;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly())
        {
        }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
            Logger = InitLogger();
            
            var spriteAsset = Bundle.LoadAsset<TMP_SpriteAsset>("Search"); // use the name of your sprite ASSET here
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
            spriteAsset.material = Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            spriteAsset.material.mainTexture = Bundle.LoadAsset<Texture2D>("Tex_Search"); // use the name of your sprite TEXTURE here

            Events.BuildGameDataEvent += (s, args) =>
            {
                if (!args.firstBuild) return;

                args.gamedata.Get<Item>(-2080052245).IsIndisposable = true; // Temporary fix for the vanilla Lasagna Tray not being indisposable
                
                foreach (Appliance appliance in args.gamedata.Get<Appliance>()) // Allows Hobs and Ovens to spawn when BBQ is present (Applies to any appliance that has the Cook process)
                {
                    if (appliance.Processes.Count <= 0) continue;
                    foreach (Appliance.ApplianceProcesses applianceProcesse in appliance.Processes)
                    {
                        if (applianceProcesse.Process != (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook)) continue;
                        if (appliance.RequiresProcessForShop.Contains((Process)GDOUtils.GetCustomGameDataObject<RequireBBQ>().GameDataObject)) continue;
                        appliance.RequiresProcessForShop.Add((Process)GDOUtils.GetCustomGameDataObject<RequireBBQ>().GameDataObject);
                        break;
                    }
                }
            };
        }
    }
}