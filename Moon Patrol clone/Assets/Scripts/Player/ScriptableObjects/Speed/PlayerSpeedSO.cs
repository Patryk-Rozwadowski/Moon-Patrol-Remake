using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/Speed")]
public class PlayerSpeedSO : ScriptableObject {
    [SerializeField] public float playerSpeed = 300f;
}