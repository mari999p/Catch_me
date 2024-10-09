using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatchMe.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [Header("Button")]
        [SerializeField] private Button _startButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
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