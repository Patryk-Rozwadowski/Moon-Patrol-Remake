#pragma warning disable 649

using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D;
    [SerializeField] private PlayerParamsSO playerParams;
    
    private float _jumpTime;
    private float _nextJump;
    private float _pos;

    private void Start() {
        _pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform
            .position.y;
    }

    private void Update() {
        Jump();
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.D) && Time.time > _nextJump) {
            _jumpTime = Time.time + playerParams.jumpTimeInAir;
            _nextJump = Time.time + playerParams.jumpCooldown + _jumpTime;
        }
        else if (Time.time < _nextJump) {
            Debug.Log($"COOLDOWN: {_nextJump - Time.time}");
        }

        tireRigidbody2D.velocity = Time.time < _jumpTime
            ? new Vector2(playerParams.playerSpeed, playerParams.jumpHeightAccelerate)
            : new Vector2(playerParams.playerSpeed, _pos);
    }
}