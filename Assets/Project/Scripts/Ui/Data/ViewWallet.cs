using TMPro;
using UnityEngine;

namespace SlimeRPG.Data
{
    public class ViewWallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;
        [SerializeField] private Wallet _wallet;

        private void OnEnable()
        {
            _wallet.OnChanged += OnUpdateCoins;
        }

        private void OnDisable()
        {
            _wallet.OnChanged -= OnUpdateCoins;
        }

        private void OnUpdateCoins(int value)
        {
            _coins.text = value.ToString();
        }
    }
}
