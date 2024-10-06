using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game
{
    public class NewBehaviourScript : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            MoveWithMouse();
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = x;
            transform.position = currentPosition;
        }

        #endregion
    }
}