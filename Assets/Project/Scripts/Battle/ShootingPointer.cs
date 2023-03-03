using Cysharp.Threading.Tasks;
using SlimeRPG.Entities;
using System.Threading;
using UnityEngine;

namespace SlimeRPG.Battle
{
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