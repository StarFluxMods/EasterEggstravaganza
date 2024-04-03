using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class HotCrossBunButtered : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "HotCrossBunButtered";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBunButtered").AssignMaterialsByNames();

        public override ItemValue ItemValue => ItemValue.SideMedium;

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<HotCrossBunCut>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(Mod.Butter)
                },
                Min = 2,
                Max = 2
            }
        };
    }
}