using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;

        public async UniTask Shoot(Transform target)
        {
            ShowProjectile();
            await _projectile.Launch(target, 1, 1);
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