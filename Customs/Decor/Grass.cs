using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Interfaces;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.Decor
{
    public class Grass : CustomDecor, IDontRegister
    {
        public override string UniqueNameID => "Grass";
        public override Material Material => MaterialUtils.GetCustomMaterial("Grass");
        public override Appliance ApplicatorAppliance => (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.FlooringApplicator);
        public override LayoutMaterialType Type => LayoutMaterialType.Floor;
        public override bool IsAvailable => true;
    }
}