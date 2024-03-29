﻿using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Entities;
using SlimeRPG.State;
using System.Threading;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Battle
{
    public class AttackingEnemyState : MonoBehaviour, IState
    {
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(0.5f)] private float _attackSpeed;

        private Player _player;
        private CancellationTokenSource _tokenSource;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
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
                _player.Damage(_damage);
                await UniTask.Delay(_attackSpeed.Millisecond(), cancellationToken: token);
            }
            while (token.IsCancellationRequested == false);
        }
    }
}