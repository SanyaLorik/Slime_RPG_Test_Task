using Cysharp.Threading.Tasks;
using SlimeRPG.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeRPG.Gameplay
{
    public class GameplayStatus : MonoBehaviour
    {
        [Header("Reloading Scene")]
        [SerializeField][Min(3)] private int _countdown;
        [SerializeField][Min(0)] private int _idScene;

        [Header("Entities")]
        [SerializeField] private GameObject _panel;
        [SerializeField] private PlayerHealth _health;
        [SerializeField] private TextMeshProUGUI _text;

        private bool _isDead = false;

        private void OnEnable()
        {
            _health.OnDead += OnReload;
        }

        private void OnDisable()
        {
            _health.OnDead -= OnReload;
        }

        private void OnReload()
        {
            if (_isDead == true) 
                return;

            _isDead = true;
            _panel.SetActive(true);

            UniTask.Create(async () =>
            {
                for (int i = _countdown - 1; i >= 0; i--)
                {
                    _text.text = i.ToString();
                    await UniTask.Delay(1000);
                }

                ReloadScene();
            });
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(_idScene);
        }
    }
}
