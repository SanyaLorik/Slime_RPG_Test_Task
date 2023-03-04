using SlimeRPG.Ui;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Factories
{
    public class ViewCoinFactory : MonoBehaviour, IViewCoinFactory
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _target;
        [SerializeField] private ViewCoin _prefab;

        private DiContainer _diContainer;

        public void Init(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Create(Transform tr)
        {
            Vector3 position = _camera.WorldToScreenPoint(tr.position);
            ViewCoin viewCoin = _diContainer.InstantiatePrefabForComponent<ViewCoin>(_prefab, position, tr.rotation, _container);

            viewCoin.Move(_target);
        }
    }
}