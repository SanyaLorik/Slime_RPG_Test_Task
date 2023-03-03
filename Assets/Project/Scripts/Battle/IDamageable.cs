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
    }

    public class Projectile : MonoBehaviour
    {

    }
}