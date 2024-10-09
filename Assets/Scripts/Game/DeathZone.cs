using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game
{
    public class DeathZone : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private bool _isActive = true;

        [Header("Audio")]
        [SerializeField] private AudioClip _audioClip;

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
                AudioService.Instance.PlaySfx(_audioClip);
            }

            else if (other.CompareTag(Tag.BadItem))
            {
                Destroy(other.gameObject);
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}