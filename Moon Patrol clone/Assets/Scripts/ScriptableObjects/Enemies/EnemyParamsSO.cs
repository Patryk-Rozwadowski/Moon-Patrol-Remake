using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemies/Params")]
public class EnemyParamsSO : ScriptableObject {
    [SerializeField] public int HP, score;
    [SerializeField] public Sprite sprite;
    [SerializeField] public float weaponRange, visionRange;
    [SerializeField] public GameObject bulletPrefab1, bulletPrefab2, deathEffect;
}