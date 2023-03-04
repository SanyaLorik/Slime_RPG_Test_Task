using SlimeRPG.Factories;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class ViewCoinFactoryBinder : MonoInstaller
    {
        [SerializeField] private ViewCoinFactory _factory;

        public override void InstallBindings()
        {
            _factory.Init(Container);

            Container
                .Bind<IViewCoinFactory>()
                .FromInstance(_factory)
                .AsCached();
        }
    }
}
