using SlimeRPG.Battle;
using SlimeRPG.Movements;
using SlimeRPG.State;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SlimeRPG.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour, IStateSwitcher, IDamageable<float>
    {
        [SerializeField] private Health _health;

        [Header("Movement State")]
        [SerializeField][Min(1)] private float _duration;

        [Header("Attacking State")]
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(1)] private float _attackSpeed;

        private IList<IState> _states;

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
            _states = new List<IState>()
            {
                new TweenMovement(this, player, _duration),
                new AttackingEnemy(this, player, _damage, _attackSpeed)
            };
        }

        public void Switch<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(i => i.GetType() == typeof(T));
            state.Enable();
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
