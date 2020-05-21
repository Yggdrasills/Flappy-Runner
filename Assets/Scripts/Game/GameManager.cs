using BaseCore.Utils.Messaging;
using FlappyRunner.Messaging;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyRunner.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _UICanvas = null;
        [SerializeField] private Image[] hearts = null;

        private Stack<Image> _heartQueue;

        private void Awake()
        {
            Time.timeScale = 1;

            _heartQueue = new Stack<Image>();

            for (int i = 0; i < hearts.Length; i++)
                _heartQueue.Push(hearts[i]);
        }

        private void OnEnable()
        {
            Signals.Get<GameOverSignal>().AddListener(ShowCanvas);
            Signals.Get<GameOverSignal>().AddListener(FreezeTime);
            Signals.Get<PlayerHitSignal>().AddListener(MakeDamage);
        }

        private void OnDisable()
        {
            Signals.Get<GameOverSignal>().RemoveListener(ShowCanvas);
            Signals.Get<GameOverSignal>().RemoveListener(FreezeTime);
            Signals.Get<PlayerHitSignal>().RemoveListener(MakeDamage);
        }

        private void ShowCanvas()
        {
            if(_UICanvas == null)
            {
                Debug.LogError("There is no canvas");
                return;
            }

            _UICanvas.SetActive(true);
        }

        private void FreezeTime()
        {
            Time.timeScale = 0;
        }

        public void RestartScene()
        {
            SceneManager.LoadScene("Game");
        }

        private void MakeDamage()
        {
            _heartQueue.Pop().enabled = false;

            if (_heartQueue.Count == 0)
            {
                Signals.Get<GameOverSignal>().Dispatch();
            }
        }
    }
}