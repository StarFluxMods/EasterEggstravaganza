using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.PlayerCosmetics
{
    public class ChickenHead : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "ChickenHead";
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("ChickenHead").AssignMaterialsByNames();
        public override bool BlockHats => true;
        
        public override void OnRegister(PlayerCosmetic gameDataObject)
        {
            GameObject Prefab = gameDataObject.Visual;

            PlayerOutfitComponent playerOutfitComponent = Prefab.AddComponent<PlayerOutfitComponent>();
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Beak").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Eye Balls").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Main Hat").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Pupils").GetComponent<SkinnedMeshRenderer>());
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Top Feathers").GetComponent<SkinnedMeshRenderer>());
        }
    }
}