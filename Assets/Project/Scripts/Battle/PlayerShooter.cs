using Cysharp.Threading.Tasks;
using SlimeRPG.Data;
using SlimeRPG.Ui;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;
        [SerializeField] private InitialAbilityValue _initialAtk;
        [SerializeField] private InitialAbilityValue _initialAspd;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private ViewAbility _viewAtk;
        [SerializeField] private ViewAbility _viewAspd;

        private Ability _atk;
        private Ability _aspd;

        private void Awake()
        {
            _atk = new Ability(_initialAtk);
            _aspd = new Ability(_initialAspd);
        }

        private void OnEnable()
        {
            _viewAtk.AddListener(OnUpgradeAtk);
            _viewAspd.AddListener(OnUpgradeAspd);
        }

        private void OnDisable()
        {
            _viewAtk.RemoveListener(OnUpgradeAtk);
            _viewAspd.RemoveListener(OnUpgradeAspd);
        }

        public async UniTask Shoot(Transform target)
        {
            ShowProjectile();
            await _projectile.Launch(target, _aspd.Value, _atk.Value);
            ReturnToStart();
            HideProjectile();
        }

        private void OnUpgradeAtk()
        {
            if (_atk.CanUpgrade(_wallet) == false)
                return;


            _wallet.Withdraw(_atk.PurchasePrice);

            _atk.Upgrade();

            _viewAtk.UpdateLevel(_atk.Level);
            _viewAtk.UpdateValue(_atk.Value);
            _viewAtk.UpdatePriceBuf(_atk.PurchasePrice);
        }

        private void OnUpgradeAspd()
        {
            if (_aspd.CanUpgrade(_wallet) == false)
                return;

            _wallet.Withdraw(_aspd.PurchasePrice);

            _aspd.Upgrade();

            _viewAspd.UpdateLevel(_aspd.Level);
            _viewAspd.UpdateValue(_aspd.Value);
            _viewAspd.UpdatePriceBuf(_aspd.PurchasePrice);
        }

        private void ReturnToStart()
        {
            _projectile.transform.position = _initialPoint.position;
        }

        private void HideProjectile()
        {
            _projectile.gameObject.SetActive(false);
        }

        private void ShowProjectile()
        {
            _projectile.gameObject.SetActive(true);
        }
    }
}