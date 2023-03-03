using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Entities
{
    public class PlayerHealth : Health
    {
        [SerializeField] private InitialAbilityValue _health;

        private void Awake()
        {
            Init(_health.Value, _health.Value);
        }
    }
}
