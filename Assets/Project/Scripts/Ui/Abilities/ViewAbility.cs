using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeRPG.Ui
{
    public class ViewAbility : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _value;
        [SerializeField] private TextMeshProUGUI _priceBuf;

        [SerializeField] private Button _improve;

        public void AddListener(Action action)
        {
            _improve.onClick.AddListener(action.Invoke);
        }

        public void RemoveListener(Action action)
        {
            _improve.onClick.RemoveListener(action.Invoke);
        }

        public void UpdateLevel(float level)
        {
            _level.text = $"Lv {level}";
        }

        public void UpdateValue(float value)
        {
            _value.text = value.ToString();
        }

        public void UpdatePriceBuf(float priceBuf)
        {
            _priceBuf.text = priceBuf.ToString();
        }
    }
}
