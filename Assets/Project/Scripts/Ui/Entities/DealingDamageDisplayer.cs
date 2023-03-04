using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SlimeRPG.Ui
{
    [RequireComponent(typeof(RectTransform))]
    public class DealingDamageDisplayer : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField][Min(0)] private float _speed;
        [SerializeField][Min(0)] private float _duration;

        private Tween _tween;

        private void Awake()
        {
            Destroy(gameObject, _duration);
        }

        private void OnDisable()
        {
            _tween?.Kill();
        }

        public void Launch(float damage)
        {
            _text.text = damage.ToString();

            _text.DOFade(0, _duration);
            _tween = _rect.DOJumpAnchorPos(Vector2.up * _speed, _speed, 1, _duration);
        }
    }
}