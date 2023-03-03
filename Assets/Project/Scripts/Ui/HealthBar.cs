using SlimeRPG.Battle;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeRPG.Ui
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _bar;
        [SerializeField] private Gradient _gradient;

        private void OnEnable()
        {
            _health.OnCurrentAsRatioChanged += OnChange;
        }

        private void OnDisable()
        {
            _health.OnCurrentAsRatioChanged -= OnChange;
        }

        private void OnChange(float value)
        {
            _bar.fillAmount = value;
            _bar.color = _gradient.Evaluate(value);
        }
    }
}