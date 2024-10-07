using CatchMe.Utility;
using UnityEngine;

namespace CatchMe.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Public methods

        public void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
        }

        #endregion
    }
}