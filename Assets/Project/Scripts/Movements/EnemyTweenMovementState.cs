﻿using SlimeRPG.Additionals;
using SlimeRPG.Battle;
using SlimeRPG.Entities;
using SlimeRPG.State;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Movements
{
    public class EnemyTweenMovementState : MonoBehaviour, IState
    {
        [SerializeField][Min(1)] private float _duration;
        [SerializeField] private float _offsetZ;

        private IStateSwitcher _switcher;
        private Transform _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player.transform;
        }

        public void Init(IStateSwitcher switcher)
        {
            _switcher = switcher;
        }

        public async void Enable()
        {
            bool result = await transform
                .FollowAlongForwardAsync(_player, _offsetZ, _duration);

            if (result == true)
                _switcher.Switch<AttackingEnemyState>();
        }
    }
}
