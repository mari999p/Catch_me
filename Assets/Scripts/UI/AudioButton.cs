using CatchMe.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatchMe.UI
{
    [RequireComponent(typeof(Button))]
    public class AudioButton : MonoBehaviour, IPointerEnterHandler
    {
        #region Variables

        [SerializeField] private AudioClip _audioClip;

        #endregion

        #region IPointerEnterHandler

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioService.Instance.PlaySfx(_audioClip);
        }

        #endregion
    }
}