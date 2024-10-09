using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUps : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioClip _audioClip;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Box))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            AudioService.Instance.PlaySfx(_audioClip);
        }

        public void SetSpeed(float speed)
        {
            
            Rigidbody2D component = GetComponent<Rigidbody2D>();
            if (component != null)
            {
                component.velocity = new Vector2(0, speed);
            }
        }

        #endregion
    }
}