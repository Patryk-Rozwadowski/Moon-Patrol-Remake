using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D;
    [SerializeField] private PlayerParamsSO playerParams;

    private float _jumpTime, _pos = 0f;

    private void Start() {
        _pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform
            .position.y;
    }

    private void Update() {
        Jump();
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.D) && Time.time > _jumpTime + playerParams.jumpTimeInAir) {
            _jumpTime = Time.time + playerParams.jumpTimeInAir;
        }
        else if (Time.time < _jumpTime) {
            Debug.Log($"COOLDOWN: {_jumpTime - Time.time}");
        }

        tireRigidbody2D.velocity = Time.time < _jumpTime
            ? new Vector2(playerParams.playerSpeed, playerParams.jumpHeightAccelerate)
            : new Vector2(playerParams.playerSpeed, _pos);
    }
}