using SlimeRPG.Entities;
using UnityEngine;

namespace SlimeRPG.Ui
{
    public class DealingDamageSpawner : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Transform _container;
        [SerializeField] private DealingDamageDisplayer _prefab;

        private void OnEnable()
        {
            _health.OnReduced += OnSpawn;
        }

        private void OnDisable()
        {
            _health.OnReduced -= OnSpawn;
        }

        private void OnSpawn(float value)
        {
            DealingDamageDisplayer displayer = Instantiate(_prefab, _container);
            displayer.Launch(value);
        }
    }
}