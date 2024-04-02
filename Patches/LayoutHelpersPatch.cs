using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Kitchen;

namespace EasterEggstravaganza.Patches
{
    /*
     * This patch is used to allow the `GetPostTiles` to allow for Garden RoomTypes
     */
    [HarmonyPatch]
    public class LayoutHelpersPatch
    {
        private static MethodBase TargetMethod()
        {
            Type type = typeof(GenericSystemBase);
            return AccessTools.FirstMethod(type, method => method.Name.Contains("GetPostTiles"));
        }

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher matcher = new(instructions);

            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldloc_S), new CodeMatch(OpCodes.Ldfld), new CodeMatch(OpCodes.Ldc_I4_0), new CodeMatch(OpCodes.Call), new CodeMatch(OpCodes.Brfalse))
                .Advance(2)
                .Set(OpCodes.Ldc_I4_1, null);

            return matcher.InstructionEnumeration();
        }
    }
}