using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class DirtyTray : CustomItem
    {
        public override string UniqueNameID => "DirtyTray";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("DirtyTray").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray);
    }
}