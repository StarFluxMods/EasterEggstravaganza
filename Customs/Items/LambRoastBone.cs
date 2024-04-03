using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class LambRoastBone : CustomItem
    {
        public override string UniqueNameID => "LambRoastBone";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LambRoastBone").AssignMaterialsByNames();

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}