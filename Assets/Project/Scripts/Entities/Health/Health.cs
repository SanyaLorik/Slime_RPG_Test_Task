using System;
using UnityEngine;

namespace SlimeRPG.Entities
{
    public abstract class Health : MonoBehaviour
    {
        public event Action<float> OnCurrentChanged;
        public event Action<float> OnCurrentAsRatioChanged;
        public event Action<float> OnReduced;
        public event Action OnDead;

        private float _current;
        private float _total;

        public void Init(float total, float current)
        {
            _total = total;
            _current = current;
        }

        public void AddTotal(float value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            _total += value;
            Change(value);
        }

        public void Add(float value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            Change(value);
        }

        public void Reduce(float value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            Change(-value);
            OnReduced?.Invoke(value);
        }

        private float CalculatedRatio => _current / _total;

        private void Change(float value)
        {
            _current = Mathf.Clamp(_current + value, 0, _total);

            OnCurrentChanged?.Invoke(_current);
            OnCurrentAsRatioChanged?.Invoke(CalculatedRatio);

            if (_current <= 0)
                OnDead?.Invoke();
        }
    }
}
