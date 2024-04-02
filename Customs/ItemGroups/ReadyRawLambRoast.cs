using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.ItemGroups
{
    public class ReadyRawLambRoast : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "ReadyRawLambRoast";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ReadyRawLambRoast").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray);

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray)
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<RawLambRoast>().GameDataObject
                },
                Min = 1,
                Max = 1
            }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<RawLambRoast>().GameDataObject,
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "RawLambRoast"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LasagneTray"),
                    DrawAll = true
                }
            };
        }
    }
}