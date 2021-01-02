using UnityEngine;

public class VehicleController : MonoBehaviour {
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private float speed = 200;
    [SerializeField] private Rigidbody2D rb;
    public static bool isInAir { get; set; }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            rb.AddForce(Vector2.up * 19f, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        if (isInAir) {
            // Debug.LogWarning("IN AIR");
            rb.freezeRotation = true;
        }
        else {
            rb.freezeRotation = false;
            backTire.AddTorque(-speed * Time.fixedDeltaTime);
        }
    }
}