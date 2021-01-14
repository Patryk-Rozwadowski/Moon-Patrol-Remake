#pragma warning disable 649

using UnityEngine;

public class PlayerScoreManager : MonoBehaviour {
    
    public int playerScore { get; set; }
    public int stageScore;
    
    public PlayerScoreManager() {
        playerScore = 0;
        stageScore = 0;
    }
    
    
    
}