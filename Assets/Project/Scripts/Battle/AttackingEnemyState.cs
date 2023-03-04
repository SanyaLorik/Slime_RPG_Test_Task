using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class AttackingEnemyState : MonoBehaviour, IState
    {
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(0.5f)] private float _attackSpeed;

        private Transform _player;
        private IStateSwitcher _switcher;

        public void Init(IStateSwitcher switcher, Transform player)
        {
            _switcher = switcher;
            _player = player;
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