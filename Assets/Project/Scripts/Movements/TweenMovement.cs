using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Movements
{
    public class TweenMovement : IState
    {
        private readonly Transform _player;

        public TweenMovement(Transform player)
        {
            _player = player;
        }

        public void Disable()
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }
    }
}
