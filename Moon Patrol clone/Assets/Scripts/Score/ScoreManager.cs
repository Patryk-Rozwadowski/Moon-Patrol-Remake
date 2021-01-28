﻿#pragma warning disable 649

using System;
using ScriptableObjects.Score;
using UnityEngine;

namespace Score {
    public class ScoreManager : MonoBehaviour {
        [SerializeField] private ScoreStoreSO scoreStore;

        private int _bestScore, _overallScore, _stageScore;

        private void Start() {
            scoreStore.playerOverallScore = 0;
            Debug.Log("SCORE MANAGEr");
        }

        public void AddOverallPlayerScore(int val) {
            scoreStore.playerOverallScore += val;
            Debug.Log($"Score manager: {scoreStore.playerOverallScore}");
        }
        // TODO stage score
    }
}