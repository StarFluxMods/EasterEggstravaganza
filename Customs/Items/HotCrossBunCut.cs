using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class HotCrossBunCut : CustomItem
    {
        public override string UniqueNameID => "HotCrossBunCut";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBunCut").AssignMaterialsByNames();

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}