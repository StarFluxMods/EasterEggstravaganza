using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace EasterEggstravaganza.Systems
{
    public class RemoveOldSourceAppliances : RestaurantSystem, IModSystem
    {
        private EntityQuery _sourceLocations;
        private EntityQuery _newIngredients;

        protected override void Initialise()
        {
            base.Initialise();
            _sourceLocations = GetEntityQuery(typeof(CApplianceIngredientSlot));
            _newIngredients = GetEntityQuery(typeof(CNeedsNewIngredient));
        }

        protected override void OnUpdate()
        {
            if (_newIngredients.CalculateEntityCount() != 0) return;
            EntityManager.DestroyEntity(_sourceLocations);
        }
    }
}