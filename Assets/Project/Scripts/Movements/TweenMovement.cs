using SlimeRPG.State;
using UnityEngine;

namespace SlimeRPG.Movements
{
    public class TweenMovement : IState
    {
        private readonly Transform _player;
        private readonly IStateSwitcher _switcher;
        private readonly float _duration;

        public TweenMovement(IStateSwitcher switcher, Transform player, float duration)
        {
            _switcher = switcher;
            _player = player;
            _duration = duration;
        }

        public void Enable()
        {

        }

        public void Disable()
        {

        }
    }
}
