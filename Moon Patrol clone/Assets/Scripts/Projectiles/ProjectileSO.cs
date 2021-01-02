using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Projectile")]
public class ProjectileSO : ScriptableObject {
    public float speed = 10f;
    public float flyingDistanceUntilDestroy;
}