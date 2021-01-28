using ScriptableObjects.Scenes;
using ScriptableObjects.Score;
using UnityEngine;
using UnityEngine.UI;

public class StageSummaryController : MonoBehaviour {
    [SerializeField] private ScoreStoreSO scoreStore;
    [SerializeField] private ScenesSO scenesSO;

    [SerializeField] private UnityEngine.UI.Text
        stagePoint,
        timeTextField,
        avgTimeTextField,
        topRecordTextField,
        goodBonusPointsField,
        brokenRecordTextField;

    void Start() {
        string[] levelStrArr = scenesSO.currentLevel.Split(' ');
        string levelStr = levelStrArr[1];
        stagePoint.text = levelStr;
    
        timeTextField.text = scoreStore.stageTime.ToString();
        avgTimeTextField.text = scoreStore.avgTime.ToString();
        // goodBonusPointsField.text = scoreStore
    }
}