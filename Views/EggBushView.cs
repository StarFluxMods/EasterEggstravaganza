using EasterEggstravaganza.Components;
using Kitchen;
using KitchenMods;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace EasterEggstravaganza.Views
{
    public class EggBushView : UpdatableObjectView<EggBushView.ViewData>
    {
        public class UpdateView : IncrementalViewSystemBase<ViewData>, IModSystem
        {
            private EntityQuery _views;
            private EntityQuery _angryCustomers;

            protected override void Initialise()
            {
                base.Initialise();
                _views = GetEntityQuery(new QueryHelper().All(typeof(CEggBush), typeof(CCanHideItem), typeof(CLinkedView)));
                _angryCustomers = GetEntityQuery(new QueryHelper().All(typeof(CShouldShakeBushes)));
            }

            protected override void OnUpdate()
            {
                bool shouldShake = _angryCustomers.CalculateEntityCount() > 0;

                using NativeArray<Entity> entities = _views.ToEntityArray(Allocator.Temp);

                for (int i = 0; i < entities.Length; i++)
                {
                    CLinkedView view = EntityManager.GetComponentData<CLinkedView>(entities[i]);
                    CCanHideItem cCanHideItem = EntityManager.GetComponentData<CCanHideItem>(entities[i]);
                    ViewData data = new ViewData
                    {
                        shouldShake = shouldShake && cCanHideItem.HiddenItem != 0
                    };
                    SendUpdate(view, data);
                }
            }
        }

        [MessagePackObject(false)]
        public struct ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData>
        {
            public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<EggBushView>();

            [Key(0)] public bool shouldShake;

            public bool IsChangedFrom(ViewData cached)
            {
                return shouldShake != cached.shouldShake;
            }
        }

        public Animator Animator;

        private static readonly int IsShaking = Animator.StringToHash("IsShaking");

        protected override void UpdateData(ViewData data)
        {
            Animator.SetBool(IsShaking, data.shouldShake);
        }
    }
}