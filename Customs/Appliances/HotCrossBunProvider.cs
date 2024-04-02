using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class HotCrossBunProvider : CustomAppliance
    {
        public override string UniqueNameID => "HotCrossBunProvider";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBunProvider").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                Available = -1,
                Maximum = -1,
                Item = GDOUtils.GetCustomGameDataObject<HotCrossBun>().ID
            }
        };

        public override PriceTier PriceTier => PriceTier.Medium;
        public override RarityTier RarityTier => RarityTier.Uncommon;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Hot Cross Buns",
                Description = "Provides Hot Cross Buns"
            })
        };
    }
}