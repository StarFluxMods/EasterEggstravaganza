using EasterEggstravaganza.Components;
using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace EasterEggstravaganza.Systems
{
    public class FindWaitingForEggs : GameSystemBase, IModSystem
    {
        private EntityQuery _waitingForEggsQuery;

        protected override void Initialise()
        {
            base.Initialise();
            _waitingForEggsQuery = GetEntityQuery(typeof(CWaitingForItem), typeof(CPatience));
        }

        protected override void OnUpdate()
        {
            using NativeArray<Entity> waitingForEggs = _waitingForEggsQuery.ToEntityArray(Allocator.Temp);
            foreach (Entity entity in waitingForEggs)
            {
                DynamicBuffer<CWaitingForItem> waitingForItemBuffer = EntityManager.GetBuffer<CWaitingForItem>(entity);
                if (!Require(entity, out CPatience cPatience)) continue;
                if (!(cPatience.RemainingTime < 0.3f)) continue;
                foreach (CWaitingForItem waitingForItem in waitingForItemBuffer)
                {
                    if (EntityManager.HasComponent<CHidableItem>(waitingForItem.Item))
                    {
                        EntityManager.AddComponent<CShouldShakeBushes>(entity);
                    }
                }
            }
        }
    }
}