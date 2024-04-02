using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class LambProvider : CustomAppliance
    {
        public override string UniqueNameID => "LambProvider";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LambProvider").AssignMaterialsByNames().AssignVFXByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                Available = -1,
                Maximum = -1,
                Item = GDOUtils.GetCustomGameDataObject<RawLambRoast>().ID
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
                Name = "Raw Lamb",
                Description = "Provides Raw Lamb"
            })
        };
    }
}