using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/parameters")]
public class PlayerParamsSO : ScriptableObject {
    [SerializeField] public float playerSpeed;
    [SerializeField] public float jumpTimeInAir;
    [SerializeField] public float jumpHeightAccelerate;
    [SerializeField] public float jumpCooldown;
}