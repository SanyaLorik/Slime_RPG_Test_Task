using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Enemy : MonoBehaviour
    {

    }

    public class EnemySpawner : MonoBehaviour
    {
        
    }

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IDamageable<float>
    {
        [SerializeField] private Health _health;

        public void Damage(float damage)
        {
            _health.Reduce(damage);
        }
    }
}
