using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/KeyboardActionKeyCodeList")]
public class KeyboardActionKeyCode : ScriptableObject {
    [SerializeField] public KeyCode jump = KeyCode.None;
    [SerializeField] public KeyCode horizontalShoot = KeyCode.None;
    [SerializeField] public KeyCode verticalShoot = KeyCode.None;
    [SerializeField] public KeyCode pause = KeyCode.None;
}