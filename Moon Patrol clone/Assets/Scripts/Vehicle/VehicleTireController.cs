using System;
using UnityEngine;

public class VehicleTireController : MonoBehaviour {
    [SerializeField] private Rigidbody2D tireRigidbody2D;
    [SerializeField] private PlayerParamsSO playerParams;
    [SerializeField] private KeyboardActionKeyCode keyboardActionKeyCode;

    private float
        _jumpTime,
        _pos,
        _playerSpeed;

    private const float
        MINSpeed = 1f,
        MAXSpeed = 6f,
        SpeedStep = 2f,
        // SpeedTolerance is for tolerance which is used to calculate differences
        // between normal vehicle speed and deviation min / max speed
        SpeedTolerance = 2f;

    private KeyCode _slowDownKey, _speedUpKey, _jumpKey;

    private bool _isJumping;
    private bool _isAnyButtonPressed;
    
    private void Start() {
        _slowDownKey = keyboardActionKeyCode.slowDown;
        _speedUpKey = keyboardActionKeyCode.speedUp;
        _jumpKey = keyboardActionKeyCode.jump;
        _playerSpeed = playerParams.playerSpeed;
        
        _pos = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down)).collider.transform
            .position.y;
    }

    private void Update() {
        Jump();
        Move();
        BackToNormalSpeed();
    }

    private void Move() {
        SlowDown();
        SpeedUp();
        MoveForward();
    }

    private void Jump() {
        bool ifPressedJumpAndReadyToJump =
            Input.GetKeyDown(_jumpKey) && Time.time > _jumpTime + playerParams.jumpTimeInAir;

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

        if (Input.GetKey(_speedUpKey) && isSlowerThanMaxSpeed) {
                Debug.Log($"min speed: {_playerSpeed}");
                _playerSpeed += Time.deltaTime * SpeedStep;
                _isAnyButtonPressed = false;
        }
        
        if (Input.GetKeyUp(_speedUpKey)) _isAnyButtonPressed = true;
    }

    private void SlowDown() {
        bool ifFasterThanMinimalSpeed = _playerSpeed >= MINSpeed;

        if (Input.GetKey(_slowDownKey) && ifFasterThanMinimalSpeed) {
            Debug.Log($"min speed: {_playerSpeed}");
            _playerSpeed -= Time.deltaTime * SpeedStep;
            _isAnyButtonPressed = false;
        }

        if (Input.GetKeyUp(_slowDownKey)) _isAnyButtonPressed = true;
    }

    private void MoveForward() {
        if (_isJumping == false) tireRigidbody2D.velocity = new Vector2(_playerSpeed, _pos);
    }

    private void BackToNormalSpeed() {
        if (Math.Abs(_playerSpeed - playerParams.playerSpeed) < SpeedTolerance && _isAnyButtonPressed) {
            if (_playerSpeed < playerParams.playerSpeed) {
                _playerSpeed += Time.deltaTime * SpeedStep;
                Debug.Log($"Speeding up {_playerSpeed}");
            } else if (_playerSpeed > playerParams.playerSpeed) {
                _playerSpeed -= Time.deltaTime * SpeedStep;
                Debug.Log($"slowing down {_playerSpeed}");
            }
        }
    }
}