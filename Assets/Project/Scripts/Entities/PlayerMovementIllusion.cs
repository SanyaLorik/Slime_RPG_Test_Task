using UnityEngine;

namespace SlimeRPG.Entities
{
    public class PlayerMovementIllusion : MonoBehaviour
    {
        [SerializeField] private EnemyWave _wave;
        [SerializeField] private Vector3 _offset;

        private Transform _camera;

        private void Awake()
        {
            _camera = transform;
        }

        private void OnEnable()
        {
            _wave.OnWaveStarted += OnMove;
        }
        private void OnDisable()
        {
            _wave.OnWaveStarted -= OnMove;
        }

        private void OnMove()
        {

        }
    }
}
