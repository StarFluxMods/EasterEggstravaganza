using EasterEggstravaganza.Customs.Appliances;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class BoxedPeep : CustomItem
    {
        public override string UniqueNameID => "BoxedPeep";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BoxedPeeps").AssignMaterialsByNames();

        public override int SplitCount => 999;

        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Peep>().GameDataObject;

        // public override bool AllowSplitMerging => true;

        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<PeepProvider>().GameDataObject;
    }
}