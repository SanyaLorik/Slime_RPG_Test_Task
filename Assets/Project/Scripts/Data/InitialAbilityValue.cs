using UnityEngine;

namespace SlimeRPG.Data
{
    [CreateAssetMenu(menuName = "Abilities/New Initial Value")]
    public class InitialAbilityValue : ScriptableObject
    {
        [field: SerializeField][field: Min(0)] public int Level { get; private set; }

        [field: SerializeField][field: Min(0)] public float Value { get; private set; }

        [field: SerializeField][field: Min(0)] public float AddingToValueAfterUpgade { get; private set; }

        [field: SerializeField][field: Min(0)] public float PurchasePrice { get; private set; }

        [field: SerializeField][field: Min(0)] public float UpgradePriceToPrice { get; private set; }
    }
}
