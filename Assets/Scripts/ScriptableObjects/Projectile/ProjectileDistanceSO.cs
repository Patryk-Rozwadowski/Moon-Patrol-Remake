using UnityEngine;

namespace ScriptableObjects.Projectile {
    [CreateAssetMenu(menuName = "ScriptableObjects/Projectile/ProjectileDistance")]
    public class ProjectileDistanceSO : ScriptableObject {
        public float projectileDistance = 0.5f;
    }
}