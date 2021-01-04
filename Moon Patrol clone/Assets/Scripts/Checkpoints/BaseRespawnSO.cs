using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseRespawn")]
public class BaseRespawnSO : ScriptableObject {
    [SerializeField] public Sprite baseSprite = null;
}