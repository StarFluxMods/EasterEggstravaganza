using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class CookedGravy : CustomItem
    {
        public override string UniqueNameID => "CookedGravy";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedGravy").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray);

        public override Item SplitSubItem => (Item)GDOUtils.GetExistingGDO(ItemReferences.TurkeyGravy);

        public override int SplitCount => 4;

        public override bool AllowSplitMerging => true;

        public override bool PreventExplicitSplit => true;

        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray)
        };

        public override string ColourBlindTag => "G";
    }
}