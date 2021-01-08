using UnityEngine;

public class VehicleController : MonoBehaviour {
    [SerializeField] private Rigidbody2D backTire = null;
    [SerializeField] private float speed = 200;
    [SerializeField] private Rigidbody2D vehicleRigidBody = null;
    public static bool isInAir { get; set; }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            vehicleRigidBody.AddForce(Vector2.up * 19f, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        if (isInAir) {
            vehicleRigidBody.freezeRotation = true;
        }
        else {
            vehicleRigidBody.freezeRotation = false;
            backTire.AddTorque(-speed * Time.fixedDeltaTime);
        }
    }
    
    public void PlayerDeath() {
        Destroy(gameObject);
        Debug.LogWarning("Player death");
    }
}