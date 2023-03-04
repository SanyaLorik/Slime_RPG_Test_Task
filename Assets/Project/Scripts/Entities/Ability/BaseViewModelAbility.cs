using SlimeRPG.Data;
using SlimeRPG.Ui;
using System;
using UnityEngine;
using Zenject;

namespace SlimeRPG
{
    public abstract class BaseViewModelAbility : MonoBehaviour
    {
        [SerializeField] private InitialAbilityValue _initialAbilityValue;
        [SerializeField] protected ViewAbility _view;

        private Wallet _wallet;
        private AlertNotEnoughPrice _alertNotEnoughtPrice;

        [Inject]
        private void Construct(Wallet wallet, AlertNotEnoughPrice alertNotEnoughtPrice)
        {
            _wallet = wallet;
            _alertNotEnoughtPrice = alertNotEnoughtPrice;
        }

        private void Awake()
        {
            Level = _initialAbilityValue.Level;
            Value = _initialAbilityValue.Value;
            AddingToValueAfterUpgade = _initialAbilityValue.AddingToValueAfterUpgade;
            PurchasePrice = _initialAbilityValue.PurchasePrice;
            UpgradePriceToPrice = _initialAbilityValue.UpgradePriceToPrice;

            UpdateView();
        }

        private void OnEnable()
        {
            _view.AddListener(OnUpgrade);
        }

        private void OnDisable()
        {
            _view.RemoveListener(OnUpgrade);
        }

        private void OnUpgrade()
        {
            if (_wallet.CanWithdrawed(PurchasePrice) == false)
            {
                _alertNotEnoughtPrice.Show();
                return;
            }

            Upgrade();
        }

        public int Level { get; protected set; }

        public float Value { get; protected set; }

        public float AddingToValueAfterUpgade { get; protected set; }

        public int PurchasePrice { get; protected set; }

        public int UpgradePriceToPrice { get; protected set; }

        protected virtual void Upgrade()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _view.UpdateLevel(Level);
            _view.UpdateValue(Value);
            _view.UpdatePriceBuf(PurchasePrice);
        }
    }
}
