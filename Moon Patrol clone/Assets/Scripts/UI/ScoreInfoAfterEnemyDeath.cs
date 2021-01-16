using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInfoAfterEnemyDeath : MonoBehaviour {
    
    [SerializeField] private Text text;

    private int _val;

    public void Show(int val, GameObject position) {
        Instantiate(gameObject, position.transform);
        text.text = $"{val}";
    }
}