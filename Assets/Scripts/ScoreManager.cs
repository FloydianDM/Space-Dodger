using System;
using UnityEngine;

namespace SpaceDodger
{
    public class ScoreManager : MonoBehaviour
    {
        public float Score {get; private set;}

        private float _scoreFloat;
        public bool IsScoreStopped;

        private void Update()
        {
            IncreaseScore();
        }

        private void IncreaseScore()
        {
            if (IsScoreStopped)
            {
                return;
            }

            _scoreFloat += Time.deltaTime * 10;
            Score = MathF.Floor(_scoreFloat);
        }

    }
}

