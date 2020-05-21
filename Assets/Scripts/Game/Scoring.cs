using BaseCore.Utils.Messaging;
using FlappyRunner.Messaging;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyRunner.Game
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private Text _scoreText = null;
        [SerializeField] private Text _highScore = null;
        private float _score = 1;

        private void OnEnable()
        {
            Signals.Get<GameOverSignal>().AddListener(SetHighScore);
        }

        private void OnDisable()
        {
            Signals.Get<GameOverSignal>().RemoveListener(SetHighScore);
        }

        private void Update()
        {
            _score += Time.deltaTime * 10;
            int score = (int)_score;
            _scoreText.text = score.ToString();
        }

        private void SetHighScore()
        {
            int highScore = PlayerPrefs.GetInt("highScore");

            if (highScore < _score)
            {
                highScore = (int)_score;
                PlayerPrefs.SetInt("highScore", highScore);
            }

            _highScore.text = highScore.ToString();
        }
    }
}