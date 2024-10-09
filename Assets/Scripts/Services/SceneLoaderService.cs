// using CatchMe.Utility;
// using UnityEngine;
// using UnityEngine.SceneManagement;
//
// namespace CatchMe.Services
// {
//     public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
//     {
//         #region Public methods
//
//         public void ExitGame()
//         {
//             Application.Quit();
//             UnityEditor.EditorApplication.isPlaying = false;
//         }
//
//         public void StartGame()
//         {
//             SceneManager.LoadScene("GameScenes");
//         }
//
//         #endregion
//     }
// }