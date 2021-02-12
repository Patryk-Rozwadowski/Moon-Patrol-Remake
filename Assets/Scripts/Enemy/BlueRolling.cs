using UnityEngine;

public class BlueRolling : MonoBehaviour {
    void Update() {
        transform.Rotate(0, 0, 180 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}