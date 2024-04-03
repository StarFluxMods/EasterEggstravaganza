using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class PeepProvider : CustomAppliance
    {
        public override string UniqueNameID => "PeepProvider";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PeepProvider").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                Available = 1,
                Maximum = 1,
                Item = GDOUtils.GetCustomGameDataObject<BoxedPeep>().ID,
                AutoPlaceOnHolder = true,
                PreventReturns = true
            },
            new CItemHolder()
        };

        public override PriceTier PriceTier => PriceTier.Medium;
        public override RarityTier RarityTier => RarityTier.Uncommon;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Pepes",
                Description = "Provides Pepes"
            })
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            
            HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            holdPointContainer.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;

            LimitedItemSourceView limitedItemSourceView = gameDataObject.Prefab.AddComponent<LimitedItemSourceView>();

            limitedItemSourceView.Items = new List<GameObject>
            {
                gameDataObject.Prefab.GetChild("HoldPoint/BoxedPeeps")
            };

            limitedItemSourceView.DisplayedItems = 1;
        }
    }
}