using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.ItemGroups
{
    public class RoastLambPlated : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "RoastLambPlated";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("RoastLambPlated").AssignMaterialsByNames().AssignVFXByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);

        public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);

        public override ItemValue ItemValue => ItemValue.Large;

        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
                    (Item)GDOUtils.GetCustomGameDataObject<LambRoastPortion>().GameDataObject,
                },
                Min = 2,
                Max = 2,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.TurkeyGravy)
                },
                Min = 0,
                Max = 1,
                RequiresUnlock = true
            }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.TurkeyGravy),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Gravy"),
                    DrawAll = true
                }
            };
        }
    }
}