using SlimeRPG.Ui;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class AlertNotEnoughPriceBinder : MonoInstaller
    {
        [SerializeField] private AlertNotEnoughPrice _alert;

        public override void InstallBindings()
        {
            Container
                .Bind<AlertNotEnoughPrice>()
                .FromInstance(_alert)
                .AsCached();
        }
    }
}
