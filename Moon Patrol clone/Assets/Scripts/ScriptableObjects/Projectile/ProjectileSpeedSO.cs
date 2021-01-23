using UnityEngine;

namespace ScriptableObjects.Projectile {
    [CreateAssetMenu(menuName = "ScriptableObjects/Projectile/ProjectileSpeed")]
    public class ProjectileSpeedSO : ScriptableObject {
        public float projectileSpeed = 10f;
    }
}