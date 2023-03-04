using DG.Tweening;
using SlimeRPG.Battle;
using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Movements
{
    public class EnemyTweenMovementState : MonoBehaviour, IState
    {
        [SerializeField][Min(2)] private float _duration;

        private IStateSwitcher _switcher;
        private Transform _player;

        private Tween _tween;

        private void OnDisable()
        {
            _tween?.Kill();
        }

        public void Init(IStateSwitcher switcher, Transform player)
        {
            _switcher = switcher;
            _player = player;
        }

        public void Enable()
        {
            float end = _player.position.z - transform.position.z;
            _tween = transform.DOMoveZ(end, _duration).SetEase(Ease.Linear).OnComplete(() => _switcher.Switch<AttackingEnemyState>(this));
        }

        public void Disable()
        {
            _tween?.Kill();
        }
    }
}
