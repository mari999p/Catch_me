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

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _gameOverLabel;
        [SerializeField] private GameObject _gameOverPanel;
        
        [SerializeField] private AudioClip _explosionAudioClip;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

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

        #region Public methods

        public void ShowGameOver()
        {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(true);
                _gameOverLabel.text = $"Game Over!\n Score: {GameService.Instance.Score}";
                PauseService.Instance.TogglePause();
            }
        }

        #endregion

        #region Private methods

        private void InitializeUI()
        {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(false);
            }

            if (_restartButton != null)
            {
                _restartButton.onClick.AddListener(OnRetryButtonClick);
            }

            if (_exitButton != null)
            {
                _exitButton.onClick.AddListener(OnExitButtonClick);
            }
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        private void OnRetryButtonClick()

        {
            PickUpService.Instance.ResetFallSpeed();
            PauseService.Instance.TogglePause();
            GameService.Instance.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void UpdateScoreLabel(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}