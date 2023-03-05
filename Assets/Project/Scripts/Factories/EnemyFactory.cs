using SlimeRPG.Entities;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy _prefab;

        private readonly Queue<Transform> _points = new Queue<Transform>();

        private DiContainer _container;

        private void Awake()
        {
            foreach (var spawnPoint in _spawnPoints)
                _points.Enqueue(spawnPoint);
        }

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public Enemy Create()
        {
            Transform point = _points.Dequeue();
            _points.Enqueue(point);

            Enemy enemy = _container.InstantiatePrefabForComponent<Enemy>(_prefab, point.position, point.rotation, point);
            return enemy;
        }
    }
}
