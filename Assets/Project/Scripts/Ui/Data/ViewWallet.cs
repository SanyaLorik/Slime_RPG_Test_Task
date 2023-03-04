using TMPro;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Data
{
    public class ViewWallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;

        private Wallet _wallet;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

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
