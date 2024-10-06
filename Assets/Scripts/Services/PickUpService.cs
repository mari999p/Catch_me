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

        [SerializeField] private List<PickUpAndProbability> _itemVariants;
        [SerializeField] private float _spawnInterval = 2f;
        [SerializeField] private float _fallSpeedIncrement = 0.1f;
        [SerializeField] private float _spawnHeight = 10f;

        private float _currentFallSpeed = 1f;

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

        #region Private methods

        private PickUp GetRandomPickUp()
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

        public void ResetFallSpeed()
        {
            _currentFallSpeed = 1f;
        }

        private void SpawnPickUp(PickUp pickUpPrefab)
        {
            float randomX = Random.Range(-4f, 4f);
            Vector3 spawnPosition = new(randomX, _spawnHeight, transform.position.z);
            PickUp pickUp = Instantiate(pickUpPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D component = pickUp.GetComponent<Rigidbody2D>();
            if (component != null)
            {
                component.velocity = new Vector2(0, -_currentFallSpeed);
            }
        }

        private IEnumerator SpawnPickUps()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                PickUp pickUp = GetRandomPickUp();
                if (pickUp != null)
                {
                    SpawnPickUp(pickUp);
                }

                _currentFallSpeed += _fallSpeedIncrement;
            }
        }

        #endregion
    }

    [Serializable]
    public class PickUpAndProbability
    {
        #region Variables

        public string name;
        public PickUp pickUpPrefab;
        [Range(0f, 100f)] public float probability;

        #endregion

        #region Public methods

        public void Validate()
        {
            name = pickUpPrefab != null ? pickUpPrefab.name : string.Empty;
        }

        #endregion
    }
}