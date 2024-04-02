using System.Collections.Generic;
using EasterEggstravaganza.Customs.Processes;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class BBQ : CustomAppliance
    {
        public override string UniqueNameID => "BBQ";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BBQ").AssignMaterialsByNames();

        public override PriceTier PriceTier => PriceTier.Medium;
        public override RarityTier RarityTier => RarityTier.Common;

        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>
        {
            new Appliance.ApplianceProcesses
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                IsAutomatic = true,
                Speed = 1,
                Validity = ProcessValidity.Generic
            },
            new Appliance.ApplianceProcesses
            {
                Process = (Process)GDOUtils.GetCustomGameDataObject<RequireBBQ>().GameDataObject,
                IsAutomatic = true,
                Speed = 1.5f,
                Validity = ProcessValidity.Generic
            }
        };

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemHolder()
        };

        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;

        public override List<Process> RequiresProcessForShop => new List<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetCustomGameDataObject<RequireBBQ>().GameDataObject
        };

        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "BBQ",
                Description = ""
            })
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            HoldPointContainer container = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            container.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;
        }
    }
}