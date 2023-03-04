using SlimeRPG.Data;
using SlimeRPG.Entities;
using UnityEngine;

namespace SlimeRPG.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Player _player;
        [SerializeField] private Wallet _wallet;

        public Enemy Spawn()
        {
            int index = Random.Range(0, _spawnPoints.Length);
            Transform point = _spawnPoints[index];

            Enemy enemy = Instantiate(_prefab, point);
            enemy.Init(_player, _wallet);

            return enemy;
        }
    }
}
