using UnityEngine;

namespace ScriptableObjects.Enemies {
    [CreateAssetMenu(menuName = "ScriptableObjects/Enemies/Params")]
    public class EnemyParamsSO : ScriptableObject {
        // TODO implement this SO into ufo prefabs
        [SerializeField] public int HP, score;
        [SerializeField] public Sprite sprite;
        [SerializeField] public float weaponRange, visionRange, timeToFlee;
        [SerializeField] public GameObject bulletPrefab1, bulletPrefab2, deathEffect;
    }
}