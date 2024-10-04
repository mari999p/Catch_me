using System;
using CatchMe.Utility;
using UnityEngine;

namespace CatchMe.Services
{
    public class GameService: SingletonMonoBehaviour<GameService>
    {
        [Header("Settings")]
        [SerializeField] private int _maxLives = 3;
        
        [Header("Stats")]
        [SerializeField] private int _score;
        [SerializeField] private int _lives;
        
        
        
        public event Action<int> OnLiveChanged;

        public event Action<int> OnScoreChanged;
        
        
        public int Lives => _lives;
        public int Score => _score;
        
        protected override void Awake()
        {
            base.Awake();

            _lives = _maxLives;
            _score = 0;
        }


        // private void Start()
        // {
        //     _lives = _maxLives;
        //     _score = 0;
        // }
        public void AddScore(int points)
        {
            _score += points;
            OnScoreChanged?.Invoke(_score);
        }

        public void CheckGameEnd()
        {
            if (_lives <= 0)
            {
                Debug.LogError("GAME OVER!");
               
            }
        }
        public void ChangeLife(int value)
        {
            _lives += value;
            _lives = Mathf.Clamp(_lives, 0, _maxLives);
            OnLiveChanged?.Invoke(_lives);
            CheckGameEnd();
        }
    }
}