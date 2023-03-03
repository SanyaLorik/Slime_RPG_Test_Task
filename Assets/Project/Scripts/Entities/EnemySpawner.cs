using UnityEngine;

namespace SlimeRPG.Entities
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy _prefab;

        public Enemy Spawn()
        {
            int index = Random.Range(0, _spawnPoints.Length);
            Transform point = _spawnPoints[index];

            return Instantiate(_prefab, point);
        }
    }
}
