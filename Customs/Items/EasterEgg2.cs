using System.Collections.Generic;
using EasterEggstravaganza.Components;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class EasterEgg2 : CustomItem
    {
        public override string UniqueNameID => "EasterEgg2";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("EasterEgg2").AssignMaterialsByNames();

        public override List<IItemProperty> Properties => new List<IItemProperty>
        {
            new CHidableItem()
        };

        public override string ColourBlindTag => "P";

        public override ItemValue ItemValue => ItemValue.Small;
    }
}