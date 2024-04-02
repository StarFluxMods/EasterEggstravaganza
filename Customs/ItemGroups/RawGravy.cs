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
    public class RawGravy : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "RawGravy";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("RawGravy").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetCustomGameDataObject<DirtyTray>().GameDataObject;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<DirtyTray>().GameDataObject
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Flour)
                },
                Min = 2,
                Max = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Duration = 5,
                Result = (Item)GDOUtils.GetCustomGameDataObject<CookedGravy>().GameDataObject
            }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Tray_Water"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Flour),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Flour"),
                    DrawAll = true
                }
            };
        }
    }
}