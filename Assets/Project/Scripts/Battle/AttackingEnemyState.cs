using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Entities;
using SlimeRPG.State;
using System.Threading;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class AttackingEnemyState : MonoBehaviour, IState
    {
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(0.5f)] private float _attackSpeed;

        private Player _player;
        private CancellationTokenSource _tokenSource;

        public void Init(Player player)
        {
            _player = player;
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
            print("ne gomofox");
        }

        public void Enable()
        {
            _tokenSource = new CancellationTokenSource();
            Attack(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid Attack(CancellationToken token)
        {
            do
            {
                print("awdawdwa");
                _player.Damage(_damage);
                await UniTask.Delay(_attackSpeed.Millisecond(), cancellationToken: token);
            }
            while (token.IsCancellationRequested == false);
        }
    }
}