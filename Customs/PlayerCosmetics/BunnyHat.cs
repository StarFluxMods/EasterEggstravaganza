using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEggstravaganza.Customs.PlayerCosmetics
{
    public class BunnyHat : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "BunnyHat";
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("Bunny Hat").AssignMaterialsByNames();
        public override bool BlockHats => true;
        
        public override void OnRegister(PlayerCosmetic gameDataObject)
        {
            GameObject Prefab = gameDataObject.Visual;

            PlayerOutfitComponent playerOutfitComponent = Prefab.AddComponent<PlayerOutfitComponent>();
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Body_4.001").GetComponent<SkinnedMeshRenderer>());
        }
    }
}