using System.Collections.Generic;
using EasterEggstravaganza.Components;
using EasterEggstravaganza.Customs.Processes;
using EasterEggstravaganza.Views;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class EggBush : CustomAppliance
    {
        public override string UniqueNameID => "EggBush";

        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bush").AssignMaterialsByNames();

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemHolder(),
            // new CStatic(),
            new CImmovable(),
            new CEggBush(),
            new CCanHideItem(),
            new CTakesDuration
            {
                Total = 1,
                Manual = true,
                Mode = InteractionMode.Items
            },
            new CDisplayDuration
            {
                Process = GDOUtils.GetCustomGameDataObject<SearchBush>().ID
            }
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);
            HoldPointContainer container = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            container.HoldPoint = gameDataObject.Prefab.GetChild("HoldPoint").transform;

            EggBushView view = gameDataObject.Prefab.AddComponent<EggBushView>();
            view.Animator = gameDataObject.Prefab.GetChild("Bush").GetComponent<Animator>();
        }
    }
}