using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRespawnController : MonoBehaviour {
    [SerializeField] private BaseRespawnSO sprite = null;


    private void Start() {
        GetComponent<SpriteRenderer>().sprite = sprite.baseSprite;
    }
}