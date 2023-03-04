using SlimeRPG.Entities;
using UnityEngine;

namespace SlimeRPG.Gameplay
{
    public class GameplayStatus : MonoBehaviour
    {
        [Header("Reloading Scene")]
        [SerializeField][Min(3)] private int _countdown;
        [SerializeField][Min(0)] private int _idScene;

        [Header("Entities")]
        [SerializeField] private PlayerHealth _playerHealth;
    }
}
