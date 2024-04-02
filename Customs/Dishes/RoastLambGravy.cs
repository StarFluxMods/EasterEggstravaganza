using System.Collections.Generic;
using EasterEggstravaganza.Customs.ItemGroups;
using EasterEggstravaganza.Customs.Items;
using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace EasterEggstravaganza.Customs.Dishes
{
    public class RoastLambGravy : CustomDish
    {
        public override string UniqueNameID => "RoastLambGravy";

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override bool IsUnlockable => true;

        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override CardType CardType => CardType.Default;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override DishType Type => DishType.Extra;

        public override int Difficulty => 1;

        public override List<Unlock> HardcodedRequirements => new List<Unlock>
        {
            (Dish)GDOUtils.GetCustomGameDataObject<RoastLamb>().GameDataObject
        };

        public override List<string> StartingNameSet => new List<string>
        {
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(Mod.LasagneTray),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Lemon),
            (Item)GDOUtils.GetCustomGameDataObject<RawLambRoast>().GameDataObject,
            (Item)GDOUtils.GetCustomGameDataObject<Garlic>().GameDataObject,
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Oil),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Flour),
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<RoastLambPlated>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.TurkeyGravy)
            }
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Fill Dirty Tray with Water and Flour, cook and portion." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Lamb Roast - Gravy",
                Description = "Adds Gravy to Lamb Roast",
                FlavourText = ""
            })
        };
    }
}