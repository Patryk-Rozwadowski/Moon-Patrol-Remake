using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantMoveFoward : MonoBehaviour {
    private Rigidbody2D _rigidbody2D;
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // TODO remove hardcoded x
        _rigidbody2D.velocity = new Vector2(5f, 0);
    }
}