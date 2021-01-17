#pragma warning disable 649

using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScoreStore")]
public class ScoreStoreSO : ScriptableObject {
    [SerializeField] public int playerOverallScore;
    [SerializeField] public int playerStageScore;
}