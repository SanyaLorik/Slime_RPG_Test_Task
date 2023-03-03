using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlimeRPG.Additionals
{
    public static class PathFollower
    {
        public static async UniTask FollowOnCurveAsync(this Transform transform, Vector3 target, AnimationCurve curve, float height, float duration)
        {
            float expandedTime = 0;
            Vector3 initial = transform.position;

            do
            {
                float lerpRatio = expandedTime / duration;
                float evaluated = curve.Evaluate(lerpRatio);

                Vector3 offset = new(0f, evaluated * height, 0);
                Vector3 position = Vector3.Lerp(initial, target, lerpRatio) + offset;

                transform.position = position;

                expandedTime += Time.deltaTime;
                await UniTask.Delay(Time.deltaTime.Millisecond());
            }
            while (expandedTime < duration);
        }
    }
}
