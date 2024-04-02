using System.Collections.Generic;
using CustomSettingsAndLayouts;
using EasterEggstravaganza.Customs.Dishes;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.RestaurantSettings
{
    public class EasterSetting : CustomRestaurantSetting
    {
        public override string UniqueNameID => "EasterSetting";
        public override WeatherMode WeatherMode => WeatherMode.None;

        public override List<IDecorationConfiguration> Decorators => new List<IDecorationConfiguration>
        {
            new CountrysideDecorator.DecorationsConfiguration
            {
                Cobblestone = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Cobblestone),
                Ground = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.CountrysideGround),
                FrontBorder = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.LogWall),
                BorderSpacing = 1,
                Scatters = new List<CountrysideDecorator.DecorationsConfiguration.Scatter>
                {
                    new CountrysideDecorator.DecorationsConfiguration.Scatter
                    {
                        Appliance = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Tree),
                        Probability = 0.35f
                    },
                    new CountrysideDecorator.DecorationsConfiguration.Scatter
                    {
                        Appliance = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Rock),
                        Probability = 0.1f
                    }
                }
            }
        };

        public override UnlockPack UnlockPack { get; protected set; }
        public override Unlock StartingUnlock => (Dish)GDOUtils.GetCustomGameDataObject<EasterEggHunt>().GameDataObject;
        public override Dish FixedDish => (Dish)GDOUtils.GetCustomGameDataObject<RoastLamb>().GameDataObject;
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("EasterSnowglobe").AssignMaterialsByNames();
        public override bool AlwaysLight => true;

        public override List<(Locale, BasicInfo)> InfoList => new List<(Locale, BasicInfo)>
        {
            (Locale.English, new BasicInfo
            {
                Name = "Easter"
            })
        };


        public override void OnRegister(RestaurantSetting gameDataObject)
        {
            base.OnRegister(gameDataObject);
            Registry.GrantCustomSetting(gameDataObject);
        }
    }
}