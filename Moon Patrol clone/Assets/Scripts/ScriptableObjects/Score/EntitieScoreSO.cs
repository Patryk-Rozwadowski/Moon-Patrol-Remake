#pragma warning disable 649

using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/scores/entityScore")]
public class EntitieScoreSO : ScriptableObject {
    [SerializeField] public int scorePoints;
}