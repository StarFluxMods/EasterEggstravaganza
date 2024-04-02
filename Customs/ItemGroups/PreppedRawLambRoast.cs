using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.ItemGroups
{
    public class PreppedRawLambRoast : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "PreppedRawLambRoast";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PreppedRawLambRoast").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray);

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<ReadyRawLambRoast>().GameDataObject
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.LemonSliced),
                    (Item)GDOUtils.GetCustomGameDataObject<PeeledGarlic>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.OilIngredient)
                },
                Min = 3,
                Max = 3
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Duration = 15,
                Result = (Item)GDOUtils.GetCustomGameDataObject<CookedLambRoastTray>().GameDataObject
            }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.LemonSliced),
                    Objects = new List<GameObject>
                    {
                        GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LemonCut1"),
                        GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LemonCut2")
                    },
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<PeeledGarlic>().GameDataObject,
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "GarlicCloves"),
                    DrawAll = true
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.OilIngredient),
                    GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "OliveOil"),
                    DrawAll = true
                }
            };
        }
    }
}