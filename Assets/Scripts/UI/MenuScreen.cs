using CatchMe.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatchMe.UI
{
    public class MenuScreen : MonoBehaviour, IPointerEnterHandler
    {
        #region Variables

        [Header("Button")]
        [SerializeField] private Button _startButton;

        [Header("Audio")]
        [SerializeField] private AudioClip _audioClip;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        #endregion

        #region IPointerEnterHandler

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioService.Instance.PlaySfx(_audioClip);
        }

        #endregion

        #region Private methods

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene("GameScenes");
        }

        #endregion
    }
}