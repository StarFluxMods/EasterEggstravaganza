using System.Collections.Generic;
using EasterEggstravaganza.Components;
using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace EasterEggstravaganza.Systems
{
    public class SpawnWaitingFood : GameSystemBase, IModSystem
    {
        private EntityQuery _items;
        private EntityQuery _eggBushes;
        private EntityQuery _waitingFoods;

        protected override void Initialise()
        {
            base.Initialise();
            _items = GetEntityQuery(new QueryHelper().All(typeof(CItem)).None(typeof(CRequestItemOf)));
            _eggBushes = GetEntityQuery(typeof(CItemHolder), typeof(CEggBush), typeof(CCanHideItem));
            _waitingFoods = GetEntityQuery(typeof(CWaitingForItem));
        }

        private readonly Dictionary<int, int> _waitingItems = new Dictionary<int, int>();

        protected override void OnUpdate()
        {
            using NativeArray<Entity> eggBushes = _eggBushes.ToEntityArray(Allocator.Temp);
            using NativeArray<Entity> waitingFoods = _waitingFoods.ToEntityArray(Allocator.Temp);
            using NativeArray<Entity> items = _items.ToEntityArray(Allocator.Temp);

            _waitingItems.Clear();

            foreach (Entity waitingFood in waitingFoods)
            {
                DynamicBuffer<CWaitingForItem> waitingForItems = EntityManager.GetBuffer<CWaitingForItem>(waitingFood);
                foreach (CWaitingForItem waitingForItem in waitingForItems)
                {
                    if (waitingForItem.Satisfied) continue;
                    if (!Has<CHidableItem>(waitingForItem.Item)) continue;

                    if (!_waitingItems.ContainsKey(waitingForItem.ItemID))
                    {
                        _waitingItems.Add(waitingForItem.ItemID, 1);
                    }
                    else
                    {
                        _waitingItems[waitingForItem.ItemID]++;
                    }
                }
            }

            foreach (int waiting in _waitingItems.Keys)
            {
                int required = _waitingItems[waiting];
                int found = 0;

                foreach (Entity item in items)
                {
                    if (!Require(item, out CItem cItem)) continue;
                    if (waiting != cItem.ID) continue;
                    found++;
                }

                foreach (Entity eggBush in eggBushes)
                {
                    if (!Require(eggBush, out CCanHideItem cCanHideItem)) continue;
                    if (waiting != cCanHideItem.HiddenItem) continue;
                    found++;
                }

                if (found >= required) continue;

                eggBushes.ShuffleInPlace();

                foreach (Entity eggBush in eggBushes)
                {
                    if (!Require(eggBush, out CItemHolder cItemHolder) || !Require(eggBush, out CCanHideItem cCanHideItem)) continue;
                    if (cItemHolder.HeldItem != Entity.Null || cCanHideItem.HiddenItem != 0) continue;
                    cCanHideItem.HiddenItem = waiting;
                    EntityManager.AddComponentData(eggBush, cCanHideItem);
                    break;
                }
            }
        }
    }
}