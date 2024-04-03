using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class LambRoastPortion : CustomItem
    {
        public override string UniqueNameID => "LambRoastPortion";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LambRoastPortion").AssignMaterialsByNames();

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}