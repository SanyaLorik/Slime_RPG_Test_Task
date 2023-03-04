using SlimeRPG.Entities;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy _prefab;

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public Enemy Create()
        {
            int index = Random.Range(0, _spawnPoints.Length);
            Transform point = _spawnPoints[index];

            Enemy enemy = _container.InstantiatePrefabForComponent<Enemy>(_prefab, point.position, point.rotation, point);
            return enemy;
        }
    }
}
