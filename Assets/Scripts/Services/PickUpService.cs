using System;
using System.Collections;
using System.Collections.Generic;
using CatchMe.Game.PickUp;
using CatchMe.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CatchMe.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Header("Prefabs list with probabilities")]
        [SerializeField] private List<PickUpAndProbability> _itemVariants;

        [Header("Interval settings")]
        [SerializeField] private float _spawnInterval = 2f;

        [Header("Height Settings PickUp")]
        [SerializeField] private float _spawnHeight = 10f;

        [Header("Speed Settings")]
        [SerializeField] private float _fallSpeedIncrement = 0.1f;
        [SerializeField] private float _currentFallSpeed = 1f;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartCoroutine(SpawnPickUps());
        }

        private void OnValidate()
        {
            foreach (PickUpAndProbability probability in _itemVariants)
            {
                probability.Validate();
            }
        }

        #endregion

        #region Public methods

        public void ResetFallSpeed() //сбрасывает скрость
        {
            _currentFallSpeed = 1f;
        }

        #endregion

        #region Private methods

        private PickUps GetRandomPickUp()
        {
            float totalProbability = 0;
            foreach (PickUpAndProbability item in _itemVariants)
            {
                totalProbability += item.probability;
            }

            float randomPoint = Random.value * totalProbability;
            foreach (PickUpAndProbability item in _itemVariants)
            {
                if (randomPoint < item.probability)
                {
                    return item.pickUpPrefab;
                }

                randomPoint -= item.probability;
            }

            return null;
        }

        private void SpawnPickUp(PickUps pickUpPrefab)
        {
            float randomX = Random.Range(-4f, 4f);
            Vector3 spawnPosition = new(randomX, _spawnHeight, transform.position.z);
            PickUps pickUp = Instantiate(pickUpPrefab, spawnPosition, Quaternion.identity);

            pickUp.SetSpeed(-_currentFallSpeed);
        }

        private IEnumerator SpawnPickUps()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                PickUps pickUp = GetRandomPickUp();
                if (pickUp != null)
                {
                    SpawnPickUp(pickUp);
                }

                _currentFallSpeed += _fallSpeedIncrement;
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class PickUpAndProbability
        {
            #region Variables

            public string name;
            public PickUps pickUpPrefab;
            [Range(0f, 100f)]
            public float probability;

            #endregion

            #region Public methods

            public void Validate()
            {
                name = pickUpPrefab != null ? pickUpPrefab.name : string.Empty;
            }

            #endregion
        }

        #endregion
    }
}