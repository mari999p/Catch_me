using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
       


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Box))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        protected virtual void PerformActions()
        {
            
            AudioService.Instance.PlaySfx(_audioClip);
        }
    }
}