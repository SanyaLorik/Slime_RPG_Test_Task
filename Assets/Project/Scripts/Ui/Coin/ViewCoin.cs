using DG.Tweening;
using UnityEngine;

namespace SlimeRPG.Ui
{
    public class ViewCoin : MonoBehaviour
    {
        [SerializeField][Min(0.25f)] private float _durationMovement;
        [SerializeField][Min(0.25f)] private float _durationShaking;

        public void Move(Transform target)
        {
            transform
                .DOShakePosition(_durationShaking, 20)
                .OnComplete(() => 
                {
                    transform.DOMove(target.position, _durationMovement);
                });
        }
    }
}
