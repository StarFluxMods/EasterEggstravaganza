using System.Collections.Generic;
using EasterEggstravaganza.Customs.ItemGroups;
using EasterEggstravaganza.Customs.Items;
using EasterEggstravaganza.Customs.Processes;
using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Dishes
{
    public class RoastLamb : CustomDish
    {
        public override string UniqueNameID => "RoastLamb";

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;

        public override bool IsUnlockable => true;

        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override CardType CardType => CardType.Default;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override DishType Type => DishType.Base;

        public override int Difficulty => 3;

        public override List<string> StartingNameSet => new List<string>
        {
            "Wooly Wonders",
            "Baa-riliant",
            "Baa Baa Que",
            "3 lambs wool",
            "Lambtastic",
            "Tender Table",
            "Meadow Meals",
            "Fleece & Flavor",
            "Lamb Lodge",
            "Eggstatic Eats",
            "Fluffy Flavors",
            "Eggcellent lamb",
            "Shepherd’s table",
            "Shepherd’s Supperhouse",
            "Flock & Flame",
            "Legacy Lambs",
            "Easter Eats ",
            "Ewe-some Eats",
            "Egg-stravaganza",
            "The Woolly Diner",
            "Lamb-licious",
            "The Baa-rbecue",
            "Fleece & Flavour "
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Lemon),
            (Item)GDOUtils.GetCustomGameDataObject<RawLambRoast>().GameDataObject,
            (Item)GDOUtils.GetCustomGameDataObject<Garlic>().GameDataObject,
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Oil),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
            (Process)GDOUtils.GetCustomGameDataObject<RequireBBQ>().GameDataObject
        };

        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("LambRoastIcon").AssignMaterialsByNames().AssignVFXByNames();

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<RoastLambPlated>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            }
        };

        public override bool IsAvailableAsLobbyOption => true;

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add Lamb into tray, combine with Chopped Lemon, Peeled Garlic, and Oil. Cook, Serve" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Lamb Roast",
                Description = "Adds Lamb Roast as a Main",
                FlavourText = ""
            })
        };
    }
}