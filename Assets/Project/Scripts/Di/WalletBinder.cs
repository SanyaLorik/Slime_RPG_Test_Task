using SlimeRPG.Data;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class WalletBinder : MonoInstaller
    {
        [SerializeField] private Wallet _wallet;

        public override void InstallBindings()
        {
            Container
                .Bind<Wallet>()
                .FromInstance(_wallet)
                .AsCached();
        }
    }
}
