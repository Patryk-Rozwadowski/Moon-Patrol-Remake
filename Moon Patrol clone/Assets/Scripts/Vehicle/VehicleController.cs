using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class VehicleController : MonoBehaviour {
    [SerializeField] private Rigidbody2D backTire = null;
    [SerializeField] private Rigidbody2D midTire = null;
    [SerializeField] private Rigidbody2D frontTire = null;
    [SerializeField] private float speed = 200;
    [SerializeField] private Rigidbody2D vehicleRigidBody = null;
    [SerializeField] private PlayerSpeedSO playerSpeed = null;
    [SerializeField] private float jumpForce = 19f;
    public static bool isInAir { get; set; }

    private bool jumping = false;
    private float jumpTime = 2f;
    private float nextJump = 0f;

    public void PlayerDeath() {
        // @ TODO add bonus for first run
        gameObject.SetActive(false);
        Debug.LogWarning("Player death");
    }
}