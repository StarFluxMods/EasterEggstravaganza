using EasterEggstravaganza.Customs.Appliances;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class RawLambRoast : CustomItem
    {
        public override string UniqueNameID => "RawLambRoast";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("RawLambRoast").AssignMaterialsByNames();

        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<LambProvider>().GameDataObject;
    }
}