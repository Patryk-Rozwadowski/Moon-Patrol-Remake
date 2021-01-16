using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/parameters")]
public class PlayerParamsSO : ScriptableObject {
    [SerializeField] public float playerSpeed = 0f;
    [SerializeField] public float jumpTimeInAir = 0f;
    [SerializeField] public float jumpHeightAccelerate = 0f;
}