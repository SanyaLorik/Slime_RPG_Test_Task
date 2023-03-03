using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlimeRPG.Additionals
{
    public static class PathFollower
    {
        public static async UniTask FollowOnCurveAsync(this Transform transform, Vector3 target, AnimationCurve curve, float height, float duration)
        {
            int millisecond = duration.Millisecond();
            float expandedTime = 0;
            Vector3 initial = transform.position;

            do
            {
                float deltaTime = Time.deltaTime;

                float lerpRatio = expandedTime / duration;
                float evaluated = curve.Evaluate(lerpRatio);

                Vector3 offset = new(0f, evaluated * height, 0);
                Vector3 position = Vector3.Lerp(initial, target, lerpRatio) + offset;

                transform.position = position;

                expandedTime += deltaTime;
                await UniTask.Delay(deltaTime.Millisecond());
            }
            while (expandedTime < millisecond);
        }
    }
}
