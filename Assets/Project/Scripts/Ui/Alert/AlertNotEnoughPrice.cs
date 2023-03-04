using DG.Tweening;
using UnityEngine;

namespace SlimeRPG.Ui
{
    public class AlertNotEnoughPrice : MonoBehaviour
    {
        [SerializeField] private Transform _source;
        [SerializeField] private Transform _initial;
        [SerializeField] private Transform _final;
        [SerializeField][Min(0)] private float _duration;

        private Tween _tween;

        public void Show()
        {
            float duration = _duration / 2;
            _source.position = _initial.position;

            _tween?.Kill();
            _tween = _source
                .DOMove(_final.position, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    _source
                        .DOMove(_initial.position, duration)
                        .SetEase(Ease.Linear);
                });
        }
    }
}
