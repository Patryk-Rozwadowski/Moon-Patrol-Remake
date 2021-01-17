using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Obstacles/ObstaclesParams")]
public class ObstaclesParamsSO : ScriptableObject {
    [SerializeField] public int jumpOverScore, destroyScore;
}