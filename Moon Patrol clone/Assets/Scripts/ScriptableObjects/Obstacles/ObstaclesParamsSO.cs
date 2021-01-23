using UnityEngine;

namespace ScriptableObjects.Obstacles {
    [CreateAssetMenu(menuName = "ScriptableObjects/Obstacles/ObstaclesParams")]
    public class ObstaclesParamsSO : ScriptableObject {
        [SerializeField] public int jumpOverScore, destroyScore;
    }
}