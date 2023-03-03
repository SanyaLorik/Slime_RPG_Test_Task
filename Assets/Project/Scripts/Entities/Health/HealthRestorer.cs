using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Entities
{
    public class HealthRestorer : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private InitialAbilityValue _healthRecovery;
        [SerializeField][Min(0)] private float _delay;

        private float _expandedTime = 0;
        private float _current;

        private void Awake()
        {
            _current = _healthRecovery.Value;
        }

        private void Update()
        {
            _expandedTime += Time.deltaTime;
            if (_expandedTime < _delay)
                return;

            _health.Add(_current);
            _expandedTime = 0;
        }
    }
}
