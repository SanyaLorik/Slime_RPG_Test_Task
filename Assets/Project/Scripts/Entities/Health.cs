using SlimeRPG.Data;
using System;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private InitialAbilityValue _health;

        public event Action<float> OnCurrentChanged;
        public event Action<float> OnCurrentAsRatioChanged;
        public event Action<float> OnTotalChanged;

        private float _current;
        private float _total;

        private void Awake()
        {
            _total = _health.Value;
            _current = _health.Value;
        }

        public void Add(float value)
        {
            Change(value);
        }

        public void Reduce(float value)
        {
            Change(-value);
        }

        private float CalculatedRatio => _current / _total;

        private void Change(float value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            _current = Mathf.Clamp(_current + value, 0, _total);
            OnCurrentChanged?.Invoke(value);
            OnCurrentChanged?.Invoke(CalculatedRatio);
        }
    }
}
