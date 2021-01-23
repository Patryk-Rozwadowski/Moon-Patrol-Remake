using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/parameters")]
public class PlayerParamsSO : ScriptableObject {
    [SerializeField] public float
        playerSpeed = 0f,
        jumpTimeInAir = 0f,
        jumpHeightAccelerate = 0f,
        minimalSpeed = 3f,
        maxSpeed = 6f,
        speedStep = 2f;
}