using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    public class BadPickUp : PickUps
    {
        #region Variables

        [Header(nameof(BadPickUp))]
        [SerializeField] private int _minPoints = 5;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.AddScore(-_minPoints);
        }

        #endregion
    }
}