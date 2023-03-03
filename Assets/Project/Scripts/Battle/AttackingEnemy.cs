using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class AttackingEnemy : IState
    {
        private readonly Transform _player;
        private readonly IStateSwitcher _switcher;
        private readonly float _damage;
        private readonly float _attackSpeed;

        public AttackingEnemy(IStateSwitcher switcher, Transform player, float damage, float attackSpeed)
        {
            _switcher = switcher;
            _player = player;
            _damage = damage;
            _attackSpeed = attackSpeed;
        }

        public void Disable()
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }
    }
}