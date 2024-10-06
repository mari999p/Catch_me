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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive)
            {
                return;
            }

            if (other.CompareTag(Tag.GoodItem))
            {
                GameService.Instance.ChangeLife(-1);
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}