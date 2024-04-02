using System.Collections.Generic;
using EasterEggstravaganza.Components;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class EasterEgg1 : CustomItem
    {
        public override string UniqueNameID => "EasterEgg1";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("EasterEgg1").AssignMaterialsByNames();

        public override List<IItemProperty> Properties => new List<IItemProperty>
        {
            new CHidableItem()
        };

        public override string ColourBlindTag => "R";

        public override ItemValue ItemValue => ItemValue.Small;
    }
}