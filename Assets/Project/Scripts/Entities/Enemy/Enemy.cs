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

        [Header("States")]
        [SerializeField] private EnemyTweenMovementState _movement;
        [SerializeField] private AttackingEnemyState _attacking;

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
            _movement.Init(this, player);
            _attacking.Init(this, player);

            _states = new List<IState>()
            {
               _movement,
               _attacking
            };
           
            _states[0].Enable();
        }

        public void Switch<T>(IState old) where T : IState
        {
            old.Disable();
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
