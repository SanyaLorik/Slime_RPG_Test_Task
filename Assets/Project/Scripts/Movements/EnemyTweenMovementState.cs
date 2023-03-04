using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Battle;
using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Movements
{
    public class EnemyTweenMovementState : MonoBehaviour, IState
    {
        [SerializeField][Min(2)] private float _duration;
        [SerializeField] private float _offsetZ;

        private IStateSwitcher _switcher;
        private Transform _player;

        public void Init(IStateSwitcher switcher, Transform player)
        {
            _switcher = switcher;
            _player = player;
        }

        public void Enable()
        {
            transform
                .FollowAlongForwardAsync(_player, _offsetZ, _duration)
                .ContinueWith(() => _switcher.Switch<AttackingEnemyState>())
                .Forget();
        }
    }
}
