using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Shooter : MonoBehaviour
    {
        [Header("Shooting")]
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;

        [Header("Settings")]
        [SerializeField] private BaseViewModelAbility _atk;
        [SerializeField] private BaseViewModelAbility _aspd;

        public async UniTask Shoot(Transform target)
        {
            ShowProjectile();
            await _projectile.Launch(target, _aspd.Value, _atk.Value);
            ReturnToStart();
            HideProjectile();
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