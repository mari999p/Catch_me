using CatchMe.Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        [SerializeField] private AudioClip _audioClipButton;

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

        private void AddButtonHoverSound(Button button)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new()
            {
                eventID = EventTriggerType.PointerEnter,
            };
            entry.callback.AddListener(_ => { OnButtonHover(); });
            trigger.triggers.Add(entry);
        }

        private void InitializeUI()
        {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(false);
            }

            if (_restartButton != null)
            {
                _restartButton.onClick.AddListener(OnRetryButtonClick);
                AddButtonHoverSound(_restartButton);
            }

            if (_exitButton != null)
            {
                _exitButton.onClick.AddListener(OnExitButtonClick);
                AddButtonHoverSound(_exitButton);
            }
        }

        private void OnButtonHover()
        {
            AudioService.Instance.PlaySfx(_audioClipButton);
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

        private void ShowGameOver()
        {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.SetActive(true);
                _gameOverLabel.text = $"Game Over!\n Score: {GameService.Instance.Score}";
                PauseService.Instance.TogglePause();
                AudioService.Instance.PlaySfx(_audioClipGameOver);
            }
        }

        private void UpdateScoreLabel(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}