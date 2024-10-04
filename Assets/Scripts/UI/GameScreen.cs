using System;
using CatchMe.Services;
using TMPro;
using UnityEngine;

namespace CatchMe.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private GameObject[] _hearts;

        private void Start()
        {
            GameService.Instance.OnScoreChanged += ScoreChangedCallback;
            GameService.Instance.OnLiveChanged += UpdateHearts;
            UpdateHearts(GameService.Instance.Lives);
            UpdateScore();

        }

        private void OnDestroy()
        {
            GameService.Instance.OnScoreChanged -= ScoreChangedCallback;;
            GameService.Instance.OnLiveChanged -= UpdateHearts;
        }
        private void ScoreChangedCallback(int i)
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }
        private void UpdateHearts(int lives)
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].SetActive(i < lives);
            }
        }
    }
}