using SlimeRPG.Entities;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Di
{
    public class PlayerBinder : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container
                .Bind<Player>()
                .FromInstance(_player)
                .AsCached();
        }
    }
}
