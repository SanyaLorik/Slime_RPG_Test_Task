﻿using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using UnityEngine;

namespace SlimeRPG.Battle
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField][Min(0)] private float _height;
        [SerializeField][Min(0)] private float _radiusExplosion;

        public async UniTask Launch(Vector3 target, float duration, float damage)
        {
            await transform.FollowOnCurveAsync(target, _curve, _height, duration);
            DealDamage(damage);
        }

        public void DealDamage(float damage)
        {
            Collider[] sphere = Physics.OverlapSphere(transform.position, _radiusExplosion);
            if (sphere.Length == 0)
                return;

            foreach (Collider collider in sphere)
            {
                if (collider.TryGetComponent(out IDamageable<float> damageable) == true)
                    damageable.Damage(damage);
            }
        }
    }
}