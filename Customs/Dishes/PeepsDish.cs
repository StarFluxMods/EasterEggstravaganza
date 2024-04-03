using System.Collections.Generic;
using EasterEggstravaganza.Customs.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

namespace EasterEggstravaganza.Customs.Dishes
{
    public class PeepsDish : CustomDish
    {
        public override string UniqueNameID => "PeepsDish";

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<Peep>().GameDataObject,
                Phase = MenuPhase.Side,
                Weight = 1
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetCustomGameDataObject<BoxedPeep>().GameDataObject
        };

        public override List<Unlock> HardcodedRequirements => new List<Unlock>
        {
            (Dish)GDOUtils.GetCustomGameDataObject<RoastLamb>().GameDataObject
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Take a Pepe from the box!" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Pepes",
                Description = "Adds Pepes as a side",
                FlavourText = ""
            })
        };
    }
}