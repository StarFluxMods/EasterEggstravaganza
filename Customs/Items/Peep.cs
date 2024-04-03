using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class Peep : CustomItem
    {
        public override string UniqueNameID => "Peep";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("LargerPeep").AssignMaterialsByNames();

        public override bool IsMergeableSide => true;

        public override ItemValue ItemValue => ItemValue.Small;
    }
}