using DG.Tweening;
using UnityEngine;

namespace SlimeRPG.Ui
{
    public class AlertNotEnoughPrice : MonoBehaviour
    {
        [SerializeField] private RectTransform _source;
        [SerializeField] private RectTransform _initial;
        [SerializeField] private RectTransform _final;
        [SerializeField][Min(0)] private float _duration;

        private Tween _tween;

        public void Show()
        {
            float duration = _duration / 2;
            _source.anchoredPosition = _initial.anchoredPosition;

            _tween?.Kill();
            _tween = _source
                .DOAnchorPos(_final.anchoredPosition, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    _source
                        .DOAnchorPos(_initial.anchoredPosition, duration)
                        .SetEase(Ease.Linear);
                });
        }
    }
}
