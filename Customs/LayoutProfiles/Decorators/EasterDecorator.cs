using System.Collections.Generic;
using System.Linq;
using EasterEggstravaganza.Customs.Appliances;
using Kitchen;
using Kitchen.Layouts;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.LayoutProfiles.Decorators
{
    public class EasterDecorator : Decorator
    {
        public override bool Decorate(Room room)
        {
            List<CLayoutAppliancePlacement> list = new List<CLayoutAppliancePlacement>();
            List<Vector2> list2 = new List<Vector2>();
            int minimumFeatures = 8;
            int maximumFeatures = 12;
            int num = 0;
            List<LayoutPosition> ShuffledPositions = (from r in Blueprint.TilesOfRoom(room) orderby UnityEngine.Random.value select r).ToList();

            foreach (LayoutPosition layoutPosition in ShuffledPositions)
            {
                if (Blueprint.IsTileOpenSpace(layoutPosition))
                {
                    bool flag = true;
                    foreach (LayoutPosition p3 in LayoutHelpers.Directions)
                    {
                        LayoutPosition layoutPosition2 = p3 + layoutPosition;
                        if (list2.Contains(layoutPosition2) || this.Blueprint.HasFeature(layoutPosition2, FeatureType.Generic))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        if (num > minimumFeatures)
                        {
                            if (UnityEngine.Random.value < 0.5f)
                            {
                                list.Add(new CLayoutAppliancePlacement
                                {
                                    Position = layoutPosition,
                                    Appliance = GDOUtils.GetCustomGameDataObject<EggBush>().ID,
                                    Rotation = Quaternion.identity
                                });
                                num++;
                            }
                        }
                        else
                        {
                            list.Add(new CLayoutAppliancePlacement
                            {
                                Position = layoutPosition,
                                Appliance = GDOUtils.GetCustomGameDataObject<EggBush>().ID,
                                Rotation = Quaternion.identity
                            });
                            num++;
                        }

                        if (num >= maximumFeatures)
                        {
                            break;
                        }

                        foreach (LayoutPosition p2 in LayoutHelpers.AllNearby)
                        {
                            LayoutPosition pos = p2 + layoutPosition;
                            list2.Add(pos);
                        }
                    }
                }
            }

            if (num > minimumFeatures && num < maximumFeatures)
            {
                Mod.Logger.LogInfo("Decorated easter room with " + num + " features");
                list.ForEach(delegate(CLayoutAppliancePlacement p) { this.Decorations.Add(p); });
                return true;
            }

            throw new LayoutFailureException("Failed to decorate easter room");
        }
    }
}