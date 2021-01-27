#pragma warning disable 649

using UnityEngine;

namespace ScriptableObjects.Score {
    [CreateAssetMenu(menuName = "ScriptableObjects/ScoreStore")]
    public class ScoreStoreSO : ScriptableObject {
        [SerializeField] public int playerOverallScore, playerStageScore, stageTime, topRecord, avgTime, goodBonus;
        [SerializeField] public string currentStage;
    }
}