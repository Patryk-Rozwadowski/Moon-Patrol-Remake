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

    
    
    private void Update() {
        
  
        if (Input.GetKeyDown(KeyCode.D)) {
            vehicleRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        if (isInAir) {
            vehicleRigidBody.freezeRotation = true;
        }
        else {
            float height = 10f;
            float pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform.position.y;
            vehicleRigidBody.freezeRotation = true;
            vehicleRigidBody.velocity = vehicleRigidBody.velocity.normalized + new Vector2(10f, pos);
        }
    }
    
    public void PlayerDeath() {
        gameObject.SetActive(false);
        Debug.LogWarning("Player death");
    }
}