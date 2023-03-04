using SlimeRPG.Data;
using TMPro;
using UnityEngine;

namespace SlimeRPG.Ui
{
    public class CommonAbibity : MonoBehaviour
    {
        [SerializeField] private InitialAbilityValue _ability;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _value;
        [SerializeField] private TextMeshProUGUI _priceBuf;

        private void Awake()
        {
            _level.text = _ability.Level.ToString();
            _value.text = _ability.Value.ToString();
            _priceBuf.text = _ability.PurchasePrice.ToString();
        }
    }
}
