using System.Collections.Generic;
using EasterEggstravaganza.Customs.Decor;
using Kitchen;
using Kitchen.Layouts;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Interfaces;
using KitchenLib.Utils;

namespace EasterEggstravaganza.Customs.Appliances
{
    public class EasterForceDiningFloor : CustomAppliance, IDontRegister
    {
        public override string UniqueNameID => "EasterForceDiningFloor";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CImmovable(),
            new CStatic(),
            new CApplyInitialDecor
            {
                Type = RoomType.Dining,
                Decor = GDOUtils.GetCustomGameDataObject<Grass>().ID
            }
        };
    }
}