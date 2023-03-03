using System;
using UnityEngine;

namespace SlimeRPG.Entities
{
    public class EnemyHealth : Health
    {
        [SerializeField][Min(0)] private float _health;

        private void Awake()
        {
            Init(_health, _health);
        }
    }
}
