using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeRPG.Ui
{
    public abstract class BaseViewAbility : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _value;
        [SerializeField] private TextMeshProUGUI _priceBuf;

        [SerializeField] private Button _improve;

        public void AddListener(Action action)
        {
            _improve.onClick.AddListener(action.Invoke);
        }

        protected void UpdateLevel(float level)
        {
            _level.text = level.ToString();
        }

        protected void UpdateValue(float value)
        {
            _value.text = value.ToString();
        }

        protected void UpdatePriceBuf(float priceBuf)
        {
            _priceBuf.text = priceBuf.ToString();
        }
    }
}
