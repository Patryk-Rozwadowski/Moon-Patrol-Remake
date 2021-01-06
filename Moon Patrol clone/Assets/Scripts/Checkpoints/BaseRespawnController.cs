﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRespawnController : MonoBehaviour {
    [SerializeField] private BaseRespawnSO sprite = null;
    [SerializeField] private GameObject vehicle = null;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = sprite.baseSprite;
        Instantiate(vehicle, gameObject.transform.transform);
    }
}