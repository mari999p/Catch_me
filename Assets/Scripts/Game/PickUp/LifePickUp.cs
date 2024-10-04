using CatchMe.Services;
using UnityEngine;

namespace CatchMe.Game.PickUp
{
    public class LifePickUp : PickUp
    {
        #region Variables

        [Header(nameof(LifePickUp))]
        [SerializeField] private int _lifeChange = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeLife(_lifeChange);
        }

        #endregion
    }
}