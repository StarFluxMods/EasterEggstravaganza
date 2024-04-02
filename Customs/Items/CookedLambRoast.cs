using System.Collections.Generic;
using System.Reflection;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Items
{
    public class CookedLambRoast : CustomItem
    {
        public override string UniqueNameID => "CookedLambRoast";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedLambRoast").AssignMaterialsByNames();

        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<LambRoastPortion>().GameDataObject;

        public override int SplitCount => 4;

        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<LambRoastBone>().GameDataObject
        };

        public override void OnRegister(Item gameDataObject)
        {
            ObjectsSplittableView view = gameDataObject.Prefab.AddComponent<ObjectsSplittableView>();

            FieldInfo info = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            List<GameObject> list = new List<GameObject>();
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LambRoast/MeatPortion4"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LambRoast/MeatPortion3"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LambRoast/MeatPortion2"));
            list.Add(GameObjectUtils.GetChildObject(gameDataObject.Prefab, "LambRoast/MeatPortion1"));
            info.SetValue(view, list);
        }
    }
}