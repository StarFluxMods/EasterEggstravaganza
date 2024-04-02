using System.Collections.Generic;
using System.Reflection;
using EasterEggstravaganza.Customs.LayoutProfiles;
using EasterEggstravaganza.Customs.LayoutProfiles.Decorators;
using HarmonyLib;
using Kitchen;
using Kitchen.Layouts;
using KitchenData;
using KitchenLib.Utils;
using Mono.WebBrowser;

namespace EasterEggstravaganza.Patches
{
    /*
     * This patch is used to run a custom Decorator set for the Easter Layout
     */
    [HarmonyPatch(typeof(LayoutDecorator), "AttemptDecoration")]
    public class LayoutDecoratorPatch
    {
        static bool Prefix(LayoutDecorator __instance)
        {
            FieldInfo _Blueprint = ReflectionUtils.GetField<LayoutDecorator>("Blueprint");
            FieldInfo _Profile = ReflectionUtils.GetField<LayoutDecorator>("Profile");
            FieldInfo _Setting = ReflectionUtils.GetField<LayoutDecorator>("Setting");

            LayoutBlueprint Blueprint = (LayoutBlueprint)_Blueprint.GetValue(__instance);
            LayoutProfile Profile = (LayoutProfile)_Profile.GetValue(__instance);
            RestaurantSetting Setting = (RestaurantSetting)_Setting.GetValue(__instance);

            if (Profile.ID != GDOUtils.GetCustomGameDataObject<EasterLayout>().ID) return true;

            __instance.Decorations = new List<CLayoutAppliancePlacement>();
            Decorator decorator = new DiningDecorator().Setup(Blueprint, Profile, null, __instance.Decorations);
            Decorator easterDecorator = new EasterDecorator().Setup(Blueprint, Profile, null, __instance.Decorations);
            Decorator decorator2 = new KitchenDecorator().Setup(Blueprint, Profile, null, __instance.Decorations);

            foreach (Room room in Blueprint.Rooms())
            {
                if (room.Type == RoomType.Garden)
                {
                    int num = 5;
                    while (num-- > 0 && !decorator.Decorate(room))
                    {
                    }

                    if (num <= 0)
                    {
                        throw new LayoutFailureException("Failed to decorate dining room");
                    }

                    easterDecorator.Decorate(room);
                }

                if (room.Type == RoomType.Kitchen)
                {
                    decorator2.Decorate(room);
                }
            }

            foreach (IDecorationConfiguration decorationConfiguration in Setting.Decorators)
            {
                try
                {
                    Decorator decorator3 = (Decorator)decorationConfiguration.Decorator;
                    decorator3.Setup(Blueprint, Profile, decorationConfiguration, __instance.Decorations);
                    decorator3.Decorate(default(Room));
                }
                catch (Exception arg)
                {
                    throw new LayoutFailureException(string.Format("Failed to apply decorator {0}: {1}", decorationConfiguration.Decorator, arg));
                }
            }

            return false;
        }
    }
}