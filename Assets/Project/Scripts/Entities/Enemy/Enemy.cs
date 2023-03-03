using SlimeRPG.Battle;
using UnityEngine;

namespace SlimeRPG.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour, IDamageable<float>
    {
        [SerializeField] private Health _health;

        [Header("Movement State")]
        [SerializeField][Min(1)] private float _duration;

        [Header("Attacking State")]
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(1)] private float _attackSpeed;

        private void OnEnable()
        {
            _health.OnCurrentChanged += OnChange;
        }

        private void OnDisable()
        {
            _health.OnCurrentChanged -= OnChange;
        }

        public void Init(Transform player)
        {

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
