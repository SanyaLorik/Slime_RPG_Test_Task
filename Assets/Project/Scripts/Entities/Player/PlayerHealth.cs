using UnityEngine;

namespace SlimeRPG.Entities
{
    public class PlayerHealth : Health
    {
        [SerializeField] private HpViewModelAbility _ability;

        private void Awake()
        {
            Init(_ability.Value, _ability.Value);
        }

        private void OnEnable()
        {
            _ability.OnAddingToTotal += AddTotal;
        }

        private void OnDisable()
        {
            _ability.OnAddingToTotal -= AddTotal;
        }
    }
}
