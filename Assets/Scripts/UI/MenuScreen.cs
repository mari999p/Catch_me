using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatchMe.UI
{
    public class MenuScreen:MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            
        }

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}