using UnityEngine;

namespace ScriptableObjects.Keyboard {
    [CreateAssetMenu(menuName = "ScriptableObjects/KeyboardActionKeyCodeList")]
    public class KeyboardActionKeyCode : ScriptableObject {
        [SerializeField] public KeyCode
            jump = KeyCode.UpArrow,
            shoot = KeyCode.Space,
            pause = KeyCode.None,
            speedUp = KeyCode.RightArrow,
            slowDown = KeyCode.LeftArrow,
            start = KeyCode.S,
            throwCoin = KeyCode.C;
    }
}