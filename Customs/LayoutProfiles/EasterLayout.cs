﻿using System.Collections.Generic;
using CustomSettingsAndLayouts;
using EasterEggstravaganza.Customs.RestaurantSettings;
using Kitchen.Layouts;
using Kitchen.Layouts.Modules;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.LayoutProfiles
{
    public class EasterLayout : CustomLayoutProfile
    {
        public override string UniqueNameID => "EasterLayout";
        public override LayoutGraph Graph => GenerateLayout(UniqueNameID);
        public override int MaximumTables => 3;
        public override List<GameDataObject> RequiredAppliances => ((LayoutProfile)GDOUtils.GetExistingGDO(LayoutProfileReferences.DinerLayout)).RequiredAppliances;
        public override GameDataObject Table => ((LayoutProfile)GDOUtils.GetExistingGDO(LayoutProfileReferences.DinerLayout)).Table;
        public override GameDataObject Counter => ((LayoutProfile)GDOUtils.GetExistingGDO(LayoutProfileReferences.DinerLayout)).Counter;
        public override Appliance ExternalBin => ((LayoutProfile)GDOUtils.GetExistingGDO(LayoutProfileReferences.DinerLayout)).ExternalBin;

        // This script was generated by Layout Builder
        public static LayoutGraph GenerateLayout(string graphName)
        {
            // Creating the graph

            LayoutGraph graph = ScriptableObject.CreateInstance<LayoutGraph>();

            // Creating all the nodes

            AddRoom AddRoom0 = ScriptableObject.CreateInstance<AddRoom>();
            RoomGrid RoomGrid0 = ScriptableObject.CreateInstance<RoomGrid>();
            AddRoom AddRoom1 = ScriptableObject.CreateInstance<AddRoom>();
            MergeRoomsByType MergeRoomsByType0 = ScriptableObject.CreateInstance<MergeRoomsByType>();
            RecentreLayout RecentreLayout0 = ScriptableObject.CreateInstance<RecentreLayout>();
            CreateFrontDoor CreateFrontDoor0 = ScriptableObject.CreateInstance<CreateFrontDoor>();
            FilterOnePerPair FilterOnePerPair0 = ScriptableObject.CreateInstance<FilterOnePerPair>();
            FilterByFreeSpace FilterByFreeSpace0 = ScriptableObject.CreateInstance<FilterByFreeSpace>();
            FindAllFeatures FindAllFeatures0 = ScriptableObject.CreateInstance<FindAllFeatures>();
            PadWithRoom PadWithRoom0 = ScriptableObject.CreateInstance<PadWithRoom>();
            SplitRooms SplitRooms0 = ScriptableObject.CreateInstance<SplitRooms>();
            AppendFeatures AppendFeatures0 = ScriptableObject.CreateInstance<AppendFeatures>();
            FilterByRoom FilterByRoom0 = ScriptableObject.CreateInstance<FilterByRoom>();
            Output Output0 = ScriptableObject.CreateInstance<Output>();
            SwitchFeatures SwitchFeatures0 = ScriptableObject.CreateInstance<SwitchFeatures>();
            FilterAdjacentPair FilterAdjacentPair0 = ScriptableObject.CreateInstance<FilterAdjacentPair>();
            FilterAdjacentPair FilterAdjacentPair1 = ScriptableObject.CreateInstance<FilterAdjacentPair>();
            SwitchFeatures SwitchFeatures1 = ScriptableObject.CreateInstance<SwitchFeatures>();
            RequireFeatures RequireFeatures0 = ScriptableObject.CreateInstance<RequireFeatures>();
            RequireAccessible RequireAccessible0 = ScriptableObject.CreateInstance<RequireAccessible>();
            AppendFeatures AppendFeatures1 = ScriptableObject.CreateInstance<AppendFeatures>();

            // Setting all the values

            AddRoom0.X = 1;
            AddRoom0.Y = -1;
            AddRoom0.Height = 1;
            AddRoom0.Width = 2;
            AddRoom0.Type = RoomType.Kitchen;
            AddRoom0.FixSeed = 0;
            AddRoom0.position = new Vector2(-2389f, -150);
            RoomGrid0.Width = 3;
            RoomGrid0.Height = 2;
            RoomGrid0.Type = RoomType.Kitchen;
            RoomGrid0.SetType = true;
            RoomGrid0.FixSeed = 0;
            RoomGrid0.position = new Vector2(-2664f, -150);
            AddRoom1.X = 0;
            AddRoom1.Y = -1;
            AddRoom1.Height = 1;
            AddRoom1.Width = 1;
            AddRoom1.Type = RoomType.Garden;
            AddRoom1.FixSeed = 0;
            AddRoom1.position = new Vector2(-2139f, -150);
            MergeRoomsByType0.FixSeed = 0;
            MergeRoomsByType0.position = new Vector2(-1489f, -150);
            RecentreLayout0.FixSeed = 0;
            RecentreLayout0.position = new Vector2(-1289f, -150);
            CreateFrontDoor0.Type = RoomType.Garden;
            CreateFrontDoor0.ForceFirstHalf = true;
            CreateFrontDoor0.FixSeed = 0;
            CreateFrontDoor0.position = new Vector2(-989f, -150);
            FilterOnePerPair0.FixSeed = 0;
            FilterOnePerPair0.position = new Vector2(-739f, 88);
            FilterByFreeSpace0.FixSeed = 0;
            FilterByFreeSpace0.position = new Vector2(-939f, 88);
            FindAllFeatures0.Feature = FeatureType.Door;
            FindAllFeatures0.FixSeed = 0;
            FindAllFeatures0.position = new Vector2(-1164f, 88);
            PadWithRoom0.Type = RoomType.Garden;
            PadWithRoom0.Above = 0;
            PadWithRoom0.Left = 5;
            PadWithRoom0.Right = 0;
            PadWithRoom0.Below = 3;
            PadWithRoom0.FixSeed = 0;
            PadWithRoom0.position = new Vector2(-1927f, -137);
            SplitRooms0.UniformX = 1;
            SplitRooms0.UniformY = 1;
            SplitRooms0.RandomX = 0;
            SplitRooms0.RandomY = 0;
            SplitRooms0.FixSeed = 0;
            SplitRooms0.position = new Vector2(-1702f, -87);
            AppendFeatures0.FixSeed = 0;
            AppendFeatures0.position = new Vector2(-414f, -150);
            FilterByRoom0.RemoveMode = false;
            FilterByRoom0.Type1 = RoomType.Kitchen;
            FilterByRoom0.FilterSecond = true;
            FilterByRoom0.Type2 = RoomType.Garden;
            FilterByRoom0.FixSeed = 0;
            FilterByRoom0.position = new Vector2(-977f, 225);
            Output0.FixSeed = 0;
            Output0.position = new Vector2(648f, -162);
            SwitchFeatures0.SetToFeature = FeatureType.Hatch;
            SwitchFeatures0.FixSeed = 0;
            SwitchFeatures0.position = new Vector2(-327f, 213);
            FilterAdjacentPair0.FixSeed = 0;
            FilterAdjacentPair0.position = new Vector2(-589f, 225);
            FilterAdjacentPair1.FixSeed = 0;
            FilterAdjacentPair1.position = new Vector2(-662f, 400);
            SwitchFeatures1.SetToFeature = FeatureType.Hatch;
            SwitchFeatures1.FixSeed = 0;
            SwitchFeatures1.position = new Vector2(-289f, 388);
            RequireFeatures0.Type = FeatureType.Hatch;
            RequireFeatures0.Minimum = 4;
            RequireFeatures0.ResultStatus = true;
            RequireFeatures0.FixSeed = 0;
            RequireFeatures0.position = new Vector2(411f, 63);
            RequireAccessible0.AllowGardens = true;
            RequireAccessible0.ResultStatus = true;
            RequireAccessible0.FixSeed = 0;
            RequireAccessible0.position = new Vector2(161f, -37);
            AppendFeatures1.FixSeed = 0;
            AppendFeatures1.position = new Vector2(-64f, -150);

            // Connecting all the nodes

            AddRoom0.GetPort("Input").Connect(RoomGrid0.GetPort("Output"));
            AddRoom1.GetPort("Input").Connect(AddRoom0.GetPort("Output"));
            MergeRoomsByType0.GetPort("Input").Connect(SplitRooms0.GetPort("Output"));
            RecentreLayout0.GetPort("Input").Connect(MergeRoomsByType0.GetPort("Output"));
            CreateFrontDoor0.GetPort("Input").Connect(RecentreLayout0.GetPort("Output"));
            FilterOnePerPair0.GetPort("Input").Connect(FilterByFreeSpace0.GetPort("Output"));
            FilterByFreeSpace0.GetPort("Input").Connect(FindAllFeatures0.GetPort("Output"));
            FindAllFeatures0.GetPort("Input").Connect(RecentreLayout0.GetPort("Output"));
            PadWithRoom0.GetPort("Input").Connect(AddRoom1.GetPort("Output"));
            SplitRooms0.GetPort("Input").Connect(PadWithRoom0.GetPort("Output"));
            AppendFeatures0.GetPort("AppendFrom").Connect(FilterOnePerPair0.GetPort("Output"));
            AppendFeatures0.GetPort("Input").Connect(CreateFrontDoor0.GetPort("Output"));
            FilterByRoom0.GetPort("Input").Connect(FindAllFeatures0.GetPort("Output"));
            Output0.GetPort("Input").Connect(RequireFeatures0.GetPort("Output"));
            SwitchFeatures0.GetPort("Input").Connect(FilterAdjacentPair0.GetPort("Output"));
            FilterAdjacentPair0.GetPort("Input").Connect(FilterByRoom0.GetPort("Output"));
            FilterAdjacentPair1.GetPort("Input").Connect(FilterByRoom0.GetPort("Output"));
            SwitchFeatures1.GetPort("Input").Connect(FilterAdjacentPair1.GetPort("Output"));
            RequireFeatures0.GetPort("Input").Connect(RequireAccessible0.GetPort("Output"));
            RequireAccessible0.GetPort("Input").Connect(AppendFeatures1.GetPort("Output"));
            AppendFeatures1.GetPort("AppendFrom").Connect(SwitchFeatures0.GetPort("Output"));
            AppendFeatures1.GetPort("AppendFrom").Connect(SwitchFeatures1.GetPort("Output"));
            AppendFeatures1.GetPort("Input").Connect(AppendFeatures0.GetPort("Output"));

            // Adding all the nodes to the graph and setting the graph

            graph.nodes.Add(AddRoom0);
            AddRoom0.graph = graph;
            graph.nodes.Add(RoomGrid0);
            RoomGrid0.graph = graph;
            graph.nodes.Add(AddRoom1);
            AddRoom1.graph = graph;
            graph.nodes.Add(MergeRoomsByType0);
            MergeRoomsByType0.graph = graph;
            graph.nodes.Add(RecentreLayout0);
            RecentreLayout0.graph = graph;
            graph.nodes.Add(CreateFrontDoor0);
            CreateFrontDoor0.graph = graph;
            graph.nodes.Add(FilterOnePerPair0);
            FilterOnePerPair0.graph = graph;
            graph.nodes.Add(FilterByFreeSpace0);
            FilterByFreeSpace0.graph = graph;
            graph.nodes.Add(FindAllFeatures0);
            FindAllFeatures0.graph = graph;
            graph.nodes.Add(PadWithRoom0);
            PadWithRoom0.graph = graph;
            graph.nodes.Add(SplitRooms0);
            SplitRooms0.graph = graph;
            graph.nodes.Add(AppendFeatures0);
            AppendFeatures0.graph = graph;
            graph.nodes.Add(FilterByRoom0);
            FilterByRoom0.graph = graph;
            graph.nodes.Add(Output0);
            Output0.graph = graph;
            graph.nodes.Add(SwitchFeatures0);
            SwitchFeatures0.graph = graph;
            graph.nodes.Add(FilterAdjacentPair0);
            FilterAdjacentPair0.graph = graph;
            graph.nodes.Add(FilterAdjacentPair1);
            FilterAdjacentPair1.graph = graph;
            graph.nodes.Add(SwitchFeatures1);
            SwitchFeatures1.graph = graph;
            graph.nodes.Add(RequireFeatures0);
            RequireFeatures0.graph = graph;
            graph.nodes.Add(RequireAccessible0);
            RequireAccessible0.graph = graph;
            graph.nodes.Add(AppendFeatures1);
            AppendFeatures1.graph = graph;
            graph.name = graphName;

            return graph;
        }

        public override void OnRegister(LayoutProfile gameDataObject)
        {
            base.OnRegister(gameDataObject);
            Registry.AddSettingLayout((RestaurantSetting)GDOUtils.GetCustomGameDataObject<EasterSetting>().GameDataObject, gameDataObject);
        }
    }
}