using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Scenes;
using ScriptableObjects.Score;
using UnityEngine;

public class StageControllerUI : MonoBehaviour {
    [SerializeField] private ScenesSO scenesSO;
    [SerializeField] private UnityEngine.UI.Text stageHudText;

    private void Start() {
        stageHudText.text = scenesSO.currentLevel;
    }
}