using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;

namespace EasterEggstravaganza.Customs.Processes
{
    public class SearchBush : CustomProcess
    {
        public override string UniqueNameID => "SearchBush";

        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>
        {
            (Locale.English, new ProcessInfo
            {
                Name = "SearchBush",
                Icon = "<sprite name=\"Search_0\">"
            })
        };
    }
}