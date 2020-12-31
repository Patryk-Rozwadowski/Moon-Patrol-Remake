using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Projectile")]
public class ProjectileSO : ScriptableObject {
    public float speed = 10f;
    public GameObject firePoint;
    public Rigidbody2D rigidBody;
    public float flyingDistanceUntilDestroy;
}