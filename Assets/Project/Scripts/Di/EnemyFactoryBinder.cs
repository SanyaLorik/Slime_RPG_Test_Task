using SlimeRPG.Factories;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class EnemyFactoryBinder : MonoInstaller
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        public override void InstallBindings()
        {
            Container
                .Bind<IEnemyFactory>()
                .FromInstance(_enemyFactory)
                .AsCached();
        }
    }
}
