﻿using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Entities
{
    public class EnemyWave : MonoBehaviour, IEnemyWave
    {
        [SerializeField][Min(0)] private int _totalWaves;
        [SerializeField][Min(2)] private int _countFromEnemies;
        [SerializeField][Range(3, 5)] private int _countToEnemies;
        [SerializeField][Min(1)] private float _delayBeforeWave;

        public event Action OnWaveStarted;
        public event Action OnWaveEnded;
        public event Action<float> OnDelayed;

        private Enemy[] _enemies;
        private IEnemyFactory _factory;

        [Inject]
        private void Construct(IEnemyFactory spawner)
        {
            _factory = spawner;
        }

        private void Start()
        {
            StartWaveSpawn().Forget();
        }

        public Enemy AliveEnemy => _enemies.FirstOrDefault(i => i != null);

        private async UniTask StartWaveSpawn()
        {
            int count = 1;

            do
            {
                Debug.Log($"Wave {count} is started.");
                var enemies = Spawn();
                OnWaveStarted?.Invoke();

                await UniTask.WaitUntil(() => enemies.All(i => i == null), cancellationToken: destroyCancellationToken);
                OnWaveEnded?.Invoke();

                OnDelayed?.Invoke(_delayBeforeWave);
                await UniTask.Delay(_delayBeforeWave.Millisecond(), cancellationToken: destroyCancellationToken);

                count++;
            }
            while (true);
        }

        private IEnumerable<Enemy> Spawn()
        {
            int count = UnityEngine.Random.Range(_countFromEnemies, _countToEnemies);
            _enemies = new Enemy[count];

            for (int i = 0; i < count; i++)
                _enemies[i] = _factory.Create();

            return _enemies;
        }
    }
}