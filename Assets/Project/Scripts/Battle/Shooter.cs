using Cysharp.Threading.Tasks;
using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _initialPoint;
        [SerializeField] private InitialAbilityValue _atk;
        [SerializeField] private InitialAbilityValue _aspd;

        private float _currentDamage;
        private float _currentDuration;

        private void Awake()
        {
            _currentDamage = _atk.Value;
            _currentDuration = _aspd.Value;
        }

        public void Start()
        {
            StartShooting().Forget();
        }

        private async UniTaskVoid StartShooting()
        {
            do
            {
                ReturnToStart();
                await Shoot();
            } 
            while (true);
        }

        private async UniTask Shoot()
        {
            await _projectile.Launch(FindEnemyPosition(), _currentDuration, _currentDamage);
        }

        private Vector3 FindEnemyPosition()
        {
            return default;
        }

        private void ReturnToStart()
        {
            _projectile.transform.position = _initialPoint.position;
        }
    }
}