using Cysharp.Threading.Tasks;
using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;
        [SerializeField] private InitialAbilityValue _atk;
        [SerializeField] private InitialAbilityValue _aspd;

        private float _currentDamage;

        private void Awake()
        {
            _currentDamage = _atk.Value;
            CurrentDuration = _aspd.Value;
        }

        public float CurrentDuration { get; private set; }

        public async UniTask Shoot(Vector3 target)
        {
            ShowProjectile();
            await _projectile.Launch(target, CurrentDuration, _currentDamage);
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