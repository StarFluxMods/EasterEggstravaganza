using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Dishes
{
    public class HotCrossBuns : CustomDish
    {
        public override string UniqueNameID => "HotCrossBuns";

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override bool IsUnlockable => true;

        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override CardType CardType => CardType.Default;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override DishType Type => DishType.Dessert;

        public override int Difficulty => 1;

        public override List<Unlock> HardcodedRequirements => new List<Unlock> { };

        public override List<string> StartingNameSet => new List<string> { };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(Mod.Butter),
            (Item)GDOUtils.GetCustomGameDataObject<HotCrossBun>().GameDataObject
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop)
        };

        public override bool RequiredNoDishItem => true;

        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("HotCrossBunsIcon").AssignMaterialsByNames().AssignVFXByNames();

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<HotCrossBunButtered>().GameDataObject,
                Phase = MenuPhase.Dessert,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            }
        };

        public override bool IsAvailableAsLobbyOption => true;

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook, Chop, and Butter your Hot Cross Buns!" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Hot Cross Buns",
                Description = "Adds Hot Cross Buns as a Dessert",
                FlavourText = ""
            })
        };
    }
}