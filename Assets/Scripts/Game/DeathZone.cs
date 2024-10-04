using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game
{
    public class DeathZone : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _isActive = true;

        #endregion

        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isActive)
            {
                return;
            }

            if (other.gameObject.CompareTag(Tag.Box))
            {
                GameService.Instance.ChangeLife(-1);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }

        #endregion
    }
}