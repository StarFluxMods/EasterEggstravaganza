using System.Collections.Generic;
using EasterEggstravaganza.Customs.Appliances;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class HotCrossBun : CustomItem
    {
        public override string UniqueNameID => "HotCrossBun";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBun").AssignMaterialsByNames();

        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<HotCrossBunProvider>().GameDataObject;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Duration = 1,
                Result = (Item)GDOUtils.GetCustomGameDataObject<HotCrossBunCooked>().GameDataObject
            }
        };
    }
}