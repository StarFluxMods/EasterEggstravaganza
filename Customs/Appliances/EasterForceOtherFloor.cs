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
    public class EasterForceOtherFloor : CustomAppliance, IDontRegister
    {
        public override string UniqueNameID => "EasterForceOtherFloor";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CImmovable(),
            new CStatic(),
            new CApplyInitialDecor
            {
                Type = RoomType.Unassigned,
                Decor = GDOUtils.GetCustomGameDataObject<Grass>().ID
            }
        };
    }
}