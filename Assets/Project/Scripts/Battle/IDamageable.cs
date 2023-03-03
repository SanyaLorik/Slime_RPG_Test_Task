using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Data;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public interface IDamageable<T>
    {
        void Damage(T damage);
    }

    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private InitialAbilityValue _atk;
        [SerializeField] private InitialAbilityValue _aspd;

        private float _currentDamage;
        private float _currentDuration;

        private void Awake()
        {
            _currentDamage = _atk.Value;
            _currentDuration = _aspd.Value;
        }

        public void Start()
        {
            Shoot();
        }

        public void Shoot()
        {
            _projectile.Launch(FindEnemyPosition(), _currentDuration, _currentDamage).Forget();
        }

        private Vector3 FindEnemyPosition()
        {
            return default;
        }
    }

    public class Projectile : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField][Min(0)] private float _height;

        public async UniTaskVoid Launch(Vector3 target, float duration, float damage)
        {
            await transform.FollowOnCurveAsync(target, _curve, _height, duration);
        }
    }
}