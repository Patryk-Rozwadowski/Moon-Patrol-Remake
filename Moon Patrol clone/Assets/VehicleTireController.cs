using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D;
    
    private bool jumping = false;
    
    private float jumpTime = 0f;
    private float jumpHeight = 2f;

    private float coolDown = 3f;
    
    private float nextJump = 0f;
    private float pos = 0f;
    private void Start() {
        pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform.position.y;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D) && Time.time > nextJump) {
            jumpTime = Time.time + jumpHeight;
            nextJump = Time.time + coolDown + jumpHeight;
        }
        else if (Time.time < nextJump){
            Debug.Log($"COOLDOWN: {nextJump - Time.time}");
        }

        tireRigidbody2D.velocity = Time.time < jumpTime ? new Vector2(5f, 1f) : new Vector2(10f, pos);
    }
}