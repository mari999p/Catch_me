using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    public class GoodPickUp : PickUps
    {
        #region Variables

        [Header(nameof(GoodPickUp))]
        [SerializeField] private int _maxPoints = 10;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.AddScore(_maxPoints);
        }

        #endregion
    }
}