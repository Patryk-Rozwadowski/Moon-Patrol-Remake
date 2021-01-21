using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D;
    [SerializeField] private PlayerParamsSO playerParams;

    // TODO get keys from scriptable object keyboard control

    private float
        _jumpTime,
        _pos,
        _playerSpeed;

    private const float 
        MINSpeed = 4f,
        MAXSpeed = 6f,
        SpeedStep = 2f;


    private bool _isJumping;

    private void Start() {
        _playerSpeed = playerParams.playerSpeed;
        _pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform
            .position.y;
    }

    private void Update() {
        Jump();
        Move();
    }

    private void Move() {
        SlowDown();
        SpeedUp();
        MoveForward();
    }

    private void Jump() {
        bool ifPressedJumpAndReadyToJump =
            Input.GetKeyDown(KeyCode.D) && Time.time > _jumpTime + playerParams.jumpTimeInAir;

        if (ifPressedJumpAndReadyToJump) _jumpTime = Time.time + playerParams.jumpTimeInAir;

        CheckIfVehicleIsStillInAir();
    }

    private void CheckIfVehicleIsStillInAir() {
        bool ifVehicleIsStillInAir = Time.time < _jumpTime;
        if (ifVehicleIsStillInAir) {
            Debug.Log($"VEHICLE IN AIR FOR: {_jumpTime - Time.time} SECONDS");
            _isJumping = true;
            tireRigidbody2D.velocity = new Vector2(_playerSpeed, playerParams.jumpHeightAccelerate);
        }
        else _isJumping = false;
    }

    private void SpeedUp() {
        bool isSlowerThanMaxSpeed = _playerSpeed <= MAXSpeed;

        if (Input.GetKey(KeyCode.R)) {
            if (isSlowerThanMaxSpeed) {
                Debug.Log($"min speed: {_playerSpeed}");
                _playerSpeed += Time.deltaTime * SpeedStep;
            }
        }
    }

    private void SlowDown() {
        bool ifFasterThanMinimalSpeed = _playerSpeed >= MINSpeed;

        if (Input.GetKey(KeyCode.E) && ifFasterThanMinimalSpeed) {
            Debug.Log($"min speed: {_playerSpeed}");
            _playerSpeed -= Time.deltaTime * SpeedStep;
            tireRigidbody2D.velocity = new Vector2(_playerSpeed, _pos);
        }
    }

    private void MoveForward() {
        if (_isJumping == false) tireRigidbody2D.velocity = new Vector2(_playerSpeed, _pos);
    }

    // If player not holding button anymore
    private void BackToNormalSpeed() {
        bool ifFasterThanNormal = _playerSpeed >= playerParams.playerSpeed;
        bool ifSlowerThanNormal = _playerSpeed <= playerParams.playerSpeed;

        if (_playerSpeed > playerParams.playerSpeed) {
            while (_playerSpeed == playerParams.playerSpeed) _playerSpeed += Time.deltaTime * SpeedStep;
            Debug.Log($"{_playerSpeed} speeding up");
        }
    }
}