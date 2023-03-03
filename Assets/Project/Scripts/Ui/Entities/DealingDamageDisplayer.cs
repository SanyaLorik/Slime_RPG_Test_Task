using TMPro;
using UnityEngine;

namespace SlimeRPG.Ui
{
    [RequireComponent(typeof(RectTransform))]
    public class DealingDamageDisplayer : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect;
        [SerializeField] private TextMeshPro _text;
        [SerializeField][Min(0)] private float _speed;

        public void Launch(float damage)
        {
            _text.text = damage.ToString();

        }
    }
}