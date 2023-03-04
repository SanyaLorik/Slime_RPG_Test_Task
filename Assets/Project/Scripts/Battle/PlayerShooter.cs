using Cysharp.Threading.Tasks;
using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;
        [SerializeField] private InitialAbilityValue _initialAtk;
        [SerializeField] private InitialAbilityValue _initialAspd;

        private Ability _atk;
        private Ability _aspd;

        private void Awake()
        {
            _atk = new Ability(_initialAtk);
            _aspd = new Ability(_initialAspd);
        }

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