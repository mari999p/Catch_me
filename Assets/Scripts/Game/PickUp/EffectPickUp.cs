using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    public class EffectPickUp : PickUps
    {
        #region Variables

        [Header(nameof(EffectPickUp))]
        [SerializeField] private int _minPoints = 50;

        [Header("Effect")]
        [SerializeField] private GameObject _effectPrefab;

        #endregion

        #region Unity lifecycle

        private void ResetGame()
        {
            GameService.Instance.Reset();
        }

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            ResetGame();
            PlayExplosionVfx();
            Destroy(gameObject);
            ApplyScore();
        }

        #endregion

        #region Private methods

        private void  ApplyScore()
        {
            GameService.Instance.AddScore(-_minPoints);
        }

        private void PlayExplosionVfx()
        {
            if (_effectPrefab != null)
            {
                Instantiate(_effectPrefab, transform.position, transform.rotation);
            }
        }

        #endregion
    }
}