using UnityEngine;

namespace SlimeRPG.Entities
{
    public class HealthRestorer : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private BaseViewModelAbility _ability;
        [SerializeField][Min(0)] private float _delay;

        private float _expandedTime = 0;

        private void Update()
        {
            _expandedTime += Time.deltaTime;
            if (_expandedTime < _delay)
                return;

            _health.Add(_ability.Value);
            _expandedTime = 0;
        }
    }
}
