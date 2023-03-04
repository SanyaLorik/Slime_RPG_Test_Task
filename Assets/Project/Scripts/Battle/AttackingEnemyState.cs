using Cysharp.Threading.Tasks;
using SlimeRPG.Additionals;
using SlimeRPG.Entities;
using SlimeRPG.State;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Battle
{
    public class AttackingEnemyState : MonoBehaviour, IState
    {
        [SerializeField][Min(25)] private float _damage;
        [SerializeField][Min(0.5f)] private float _attackSpeed;

        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public void Enable()
        {
            Attack().Forget();
        }

        private async UniTaskVoid Attack()
        {
            _player.Damage(_damage);
            await UniTask.Delay(_attackSpeed.Millisecond());
        }
    }
}