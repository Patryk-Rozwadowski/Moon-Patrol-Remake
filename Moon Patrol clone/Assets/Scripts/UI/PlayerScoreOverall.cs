﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreOverall : MonoBehaviour {
    [SerializeField] private Text text;
    [SerializeField] private ScoreStoreSO _scoreStore;

    private void Update() {
        text.text = $"{_scoreStore.playerOverallScore}";
    }
}