using SlimeRPG.Additionals;
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

        private void OnDisable()
        {

        }

        public void Init(IStateSwitcher switcher, Transform player)
        {
            _switcher = switcher;
            _player = player;
        }

        public void Enable()
        {
            transform.FollowAlongForwardAsync(_player, _offsetZ, _duration).Forget();
        }

        public void Disable()
        {

        }
    }
}
