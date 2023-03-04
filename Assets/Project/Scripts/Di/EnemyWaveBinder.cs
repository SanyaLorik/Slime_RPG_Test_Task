using SlimeRPG.Entities;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class EnemyWaveBinder : MonoInstaller
    {
        [SerializeField] private EnemyWave _enemyWave;

        public override void InstallBindings()
        {
            Container
                .Bind<IEnemyWave>()
                .FromInstance(_enemyWave)
                .AsCached();
        }
    }
}
