using System;
using UnityEngine;

namespace SlimeRPG.Data
{
    public class Wallet : MonoBehaviour
    {
        public event Action<int> OnChanged;

        private int _current = 0;

        public bool CanWithdrawed(int count)
        {
            return _current >= count;
        }

        public void Add(int value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            Change(value);
        }

        public void Withdraw(int value)
        {
            if (value < 0)
                throw new Exception("Value can not be less than 0.");

            Change(-value);
        }

        private void Change(int value)
        {
            _current += value;//
            OnChanged.Invoke(_current);
        }
    }
}
