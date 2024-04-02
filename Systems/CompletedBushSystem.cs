using EasterEggstravaganza.Components;
using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace EasterEggstravaganza.Systems
{
    public class CompletedBushSystem : GameSystemBase, IModSystem
    {
        private EntityQuery _eggBushes;

        protected override void Initialise()
        {
            base.Initialise();
            _eggBushes = GetEntityQuery(typeof(CItemHolder), typeof(CEggBush), typeof(CCanHideItem));
        }

        protected override void OnUpdate()
        {
            using NativeArray<Entity> eggBushes = _eggBushes.ToEntityArray(Allocator.Temp);
            foreach (Entity eggBush in eggBushes)
            {
                if (Require(eggBush, out CCanHideItem cCanHideItem) && Require(eggBush, out CTakesDuration cTakesDuration))
                {
                    if (!cTakesDuration.Active) continue;
                    if (!(cTakesDuration.Remaining <= 0)) continue;
                    if (cCanHideItem.HiddenItem == 0) continue;

                    Entity createItemRequest = EntityManager.CreateEntity(typeof(CCreateItem));
                    EntityManager.SetComponentData(createItemRequest, new CCreateItem
                    {
                        ID = cCanHideItem.HiddenItem,
                        Holder = eggBush
                    });
                    cCanHideItem.HiddenItem = 0;
                    EntityManager.SetComponentData(eggBush, cCanHideItem);
                }
            }
        }
    }
}