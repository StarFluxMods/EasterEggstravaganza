using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

namespace EasterEggstravaganza.Customs.Dishes
{
    public class EasterEggHunt : CustomDish
    {
        public override string UniqueNameID => "EasterEggHunt";

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;

        public override bool IsUnlockable => false;

        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override CardType CardType => CardType.Default;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override DishType Type => DishType.Dessert;

        public override int Difficulty => 1;

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>();

        public override List<Unlock> HardcodedRequirements => new List<Unlock>();

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>();

        public override bool RequiredNoDishItem => true;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<EasterEgg1>().GameDataObject,
                Phase = MenuPhase.Starter,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            },
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<EasterEgg2>().GameDataObject,
                Phase = MenuPhase.Starter,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            },
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<EasterEgg3>().GameDataObject,
                Phase = MenuPhase.Starter,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            }
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Customer wants an Easter Egg? Have a look through the bushes, you might find what you're looking for!" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Easter Eggs",
                Description = "Adds Easter Eggs as a Starter",
                FlavourText = "Where did you come from? Where did you go?"
            })
        };
    }
}