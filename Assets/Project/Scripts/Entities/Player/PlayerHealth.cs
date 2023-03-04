using UnityEngine;

namespace SlimeRPG.Entities
{
    public class PlayerHealth : Health
    {
        [SerializeField] private BaseViewModelAbility _ability;

        private void Awake()
        {
            Init(_ability.Value, _ability.Value);
        }
    }
}
