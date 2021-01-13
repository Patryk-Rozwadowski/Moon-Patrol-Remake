using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemies/Params")]
public class EnemyParamsSO : ScriptableObject {
    [SerializeField] public int HP;
    [SerializeField] public Sprite sprite;
    [SerializeField] public float weaponRange;
    [SerializeField] public float visionRange;
    [SerializeField] public GameObject bulletPrefab;
}