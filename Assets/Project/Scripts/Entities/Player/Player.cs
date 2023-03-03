using SlimeRPG.Battle;
using UnityEngine;

namespace SlimeRPG.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Player : MonoBehaviour, IDamageable<float>
    {
        [SerializeField] private Health _health;

        public void Damage(float damage)
        {
            _health.Reduce(damage);
        }
    }
}
