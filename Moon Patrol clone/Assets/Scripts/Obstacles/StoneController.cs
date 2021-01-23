#pragma warning disable 649
using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;

namespace Obstacles {
    public class StoneController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO rockScore;
        public void Destroy() {
            ScoreManager scoreManager = GetComponent<ScoreManager>();
            scoreManager.AddOverallPlayerScore(rockScore.destroyScore);
            Destroy(gameObject);
            // TODO place for explosion effect
        }
    }
}