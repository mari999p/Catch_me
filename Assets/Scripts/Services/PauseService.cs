using System;
using CatchMe.Utility;
using UnityEngine;

namespace CatchMe.Services
{
    public class PauseService: SingletonMonoBehaviour<PauseService>
    {
        public event Action<bool> OnChanged;
        public bool IsPaused { get; private set; }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
        public void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            OnChanged?.Invoke(IsPaused);
        }
    }
}