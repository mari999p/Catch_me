using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    public class EffectPickUp : PickUp
    {
        #region Variables

        [Header(nameof(EffectPickUp))]
        [Header("Damage")]
        [SerializeField] private int _damage = 50;

        [Header("Effect")]
        [SerializeField] private Object _effectPrefab;

        #endregion

        #region Unity lifecycle

        private void Reset()
        {
            GameService.Instance.Reset();
        }

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            Reset();
            Explode();
            Destroy(gameObject);
            ApplyExplosionEffects();
        }

        #endregion

        #region Private methods

        private void ApplyExplosionEffects()
        {
            GameService.Instance.AddScore(-_damage);
        }

        private void Explode()
        {
            if (_effectPrefab != null)
            {
                Instantiate(_effectPrefab, transform.position, transform.rotation);
            }
        }

        #endregion
    }
}