using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/KeyboardActionKeyCodeList")]
public class KeyboardActionKeyCode : ScriptableObject {
    [SerializeField] public KeyCode
        jump = KeyCode.None,
        shoot = KeyCode.None,
        pause = KeyCode.None,
        speedUp = KeyCode.None,
        slowDown = KeyCode.None,
        start = KeyCode.None,
        throwCoin = KeyCode.None;
}