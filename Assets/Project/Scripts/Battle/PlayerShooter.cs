using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Data;
using SlimeRPG.Entities;
using System;
using System.Threading;
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
    public class ShootingPointer : MonoBehaviour
    {
        [SerializeField] private PlayerShooter _shooter;
        [SerializeField] private EnemyWave _wave;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _wave.OnWaveStarted += OnStartShooting;
            _wave.OnWaveEnded += OnStopShooting;
        }

        private void OnDisable()
        {
            _wave.OnWaveStarted -= OnStartShooting;
            _wave.OnWaveEnded -= OnStopShooting;

            _tokenSource?.Cancel();
        }

        private void OnStartShooting()
        {
            _tokenSource = new CancellationTokenSource();
            ProcessShooting(_tokenSource.Token).Forget();
        }

        private void OnStopShooting()
        {
            _tokenSource?.Cancel();
        }

        private async UniTask ProcessShooting(CancellationToken token)
        {
            do
            {
                await _shooter.Shoot(_wave.AliveEnemy.transform.position);
                //await UniTask.Delay(_shooter.CurrentDuration.Millisecond(), cancellationToken: token);
            }
            while (token.IsCancellationRequested == false);
        }
    }
}