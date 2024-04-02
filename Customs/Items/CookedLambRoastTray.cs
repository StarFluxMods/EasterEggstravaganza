using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class CookedLambRoastTray : CustomItem
    {
        public override string UniqueNameID => "CookedLambRoastTray";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedLambRoastTray").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray);

        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<CookedLambRoast>().GameDataObject;

        public override int SplitCount => 1;

        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<DirtyTray>().GameDataObject
        };
    }
}