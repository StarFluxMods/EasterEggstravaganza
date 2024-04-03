using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class HotCrossBunCooked : CustomItem
    {
        public override string UniqueNameID => "HotCrossBunCooked";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBunCooked").AssignMaterialsByNames();

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Duration = 1,
                Result = (Item)GDOUtils.GetCustomGameDataObject<HotCrossBunCut>().GameDataObject
            }
        };
    }
}