using System.Collections.Generic;
using EasterEggstravaganza.Customs.Appliances;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace EasterEggstravaganza.Customs.Processes
{
    public class RequireBBQ : CustomProcess
    {
        public override string UniqueNameID => "RequireBBQ";
        public override GameDataObject BasicEnablingAppliance => (Appliance)GDOUtils.GetCustomGameDataObject<BBQ>().GameDataObject;
        public override Process IsPseudoprocessFor => (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook);

        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>
        {
            (Locale.English, new ProcessInfo
            {
                Name = "Require BBQ",
                Icon = "<sprite name=\"cook\">"
            })
        };
    }
}