using SlimeRPG.Battle;
using UnityEngine;

namespace SlimeRPG.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour, IDamageable<float>
    {
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.OnCurrentChanged += OnChange;
        }

        private void OnDisable()
        {
            _health.OnCurrentChanged -= OnChange;
        }

        private void OnChange(float value)
        {
            if (value <= 0)
                Destroy(gameObject);
        }

        public void Damage(float damage)
        {
            _health.Reduce(damage);
        }
    }
}
