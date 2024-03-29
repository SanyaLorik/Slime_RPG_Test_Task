﻿using DG.Tweening;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Entities
{
    public class PlayerMovementIllusion : MonoBehaviour
    {
        [SerializeField] private Transform _initial;
        [SerializeField] private Transform _target;

        private Transform _camera;

        private IEnemyWave _wave;

        [Inject]
        private void Construct(IEnemyWave wave)
        {
            _wave = wave;
        }

        private void Awake()
        {
            _camera = Camera.main.transform;
        }

        private void OnEnable()
        {
            _wave.OnDelayed += OnMove;
        }

        private void OnDisable()
        {
            _wave.OnDelayed -= OnMove;
        }

        private void OnMove(float dealy)
        {
            float dalay = dealy / 2;
            _camera
                .DOMove(_target.position, dalay)
                .OnComplete(() => _camera.DOMove(_initial.position, dalay));
        }
    }
}
