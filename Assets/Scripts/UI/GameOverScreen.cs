using CatchMe.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatchMe.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [Header("Panel Settings")]
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _gameOverLabel;
        [SerializeField] private GameObject _gameOverPanel;

        [Header("Buttons")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        [Header("Audio")]
        [SerializeField] private AudioClip _audioClipGameOver;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.OnGameOver += ShowGameOver;
            UpdateScoreLabel(GameService.Instance.Score);
            InitializeUI();
        }

        private void OnDestroy()
        {
            GameService.Instance.OnGameOver -= ShowGameOver;
        }

        #endregion

        #region Private methods

        private void ExitButtonClickedCallback()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        private void InitializeUI()
        {
            _gameOverPanel.SetActive(false);

            _restartButton.onClick.AddListener(RetryButtonClickedCallback);
            _exitButton.onClick.AddListener(ExitButtonClickedCallback);
        }

        private void RetryButtonClickedCallback()

        {
            PickUpService.Instance.ResetFallSpeed();
            PauseService.Instance.TogglePause();
            GameService.Instance.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void ShowGameOver()
        {
            _gameOverPanel.SetActive(true);
            _gameOverLabel.text = $"Game Over!\n Score: {GameService.Instance.Score}";
            PauseService.Instance.TogglePause();
            AudioService.Instance.PlaySfx(_audioClipGameOver);
        }

        private void UpdateScoreLabel(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}