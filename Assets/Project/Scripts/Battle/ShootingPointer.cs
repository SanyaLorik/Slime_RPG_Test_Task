using Cysharp.Threading.Tasks;
using SlimeRPG.Entities;
using System.Threading;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Battle
{
    public class ShootingPointer : MonoBehaviour
    {
        [SerializeField] private Shooter _shooter;

        private IEnemyWave _wave;
        private CancellationTokenSource _tokenSource;

        [Inject]
        private void Construct(IEnemyWave wave)
        {
            _wave = wave;
        }

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
                await _shooter.Shoot(_wave.AliveEnemy.transform);
            }
            while (token.IsCancellationRequested == false);
        }
    }
}