using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game
{
    public class Box : MonoBehaviour
    {
        #region Variables

        [Header("Border settings")]
        [SerializeField] private float _screenLeft;
        [SerializeField] private float _screenRight;

        #endregion

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

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                SetXPosition(worldPosition.x);
            }
            // Vector3 mousePosition = Input.mousePosition;
            // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;

            float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, transform.position.z)).x +
                               _screenLeft;
            float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z)).x -
                                _screenRight;
            currentPosition.x = Mathf.Clamp(x, screenLeft, screenRight);
            transform.position = currentPosition;
        }

        #endregion
    }
}