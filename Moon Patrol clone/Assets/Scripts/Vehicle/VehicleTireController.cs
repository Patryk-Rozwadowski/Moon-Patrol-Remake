#pragma warning disable 649
using System;
using ScriptableObjects.Keyboard;
using ScriptableObjects.Player;
using UnityEngine;

namespace Vehicle {
    public class VehicleTireController : MonoBehaviour {
        [SerializeField] private Rigidbody2D tireRigidbody2D;
        [SerializeField] private PlayerParamsSO playerParams;
        [SerializeField] private KeyboardActionKeyCodeSO keyboardActionKeyCodeSo;

        private float
            _jumpTime,
            _pos,
            _playerSpeed,
            _minSpeed,
            _maxSpeed,
            _speedStep,
            _playerHorizontalJumpSpeed;

        // SpeedTolerance is for tolerance which is used to calculate differences
        // between normal vehicle speed and deviation min / max speed
        private float _speedTolerance;

        private KeyCode _slowDownKey, _speedUpKey, _jumpKey;

        private bool _isJumping, _isAnyButtonPressed;

        private void Start() {
            _slowDownKey = keyboardActionKeyCodeSo.slowDown;
            _speedUpKey = keyboardActionKeyCodeSo.speedUp;
            _jumpKey = keyboardActionKeyCodeSo.jump;
            _playerSpeed = playerParams.playerSpeed;
            _playerHorizontalJumpSpeed = playerParams.jumpHorizontalSpeed;
            _minSpeed = playerParams.minimalSpeed;
            _maxSpeed = playerParams.maxSpeed;
            _speedStep = playerParams.speedStep;
            _speedTolerance = playerParams.maxSpeed - playerParams.minimalSpeed;

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

            if (ifPressedJumpAndReadyToJump) {
                _jumpTime = Time.time + playerParams.jumpTimeInAir;
                FindObjectOfType<AudioManager>().Play("Jump");
            }

            CheckIfVehicleIsStillInAir();
        }

        private void CheckIfVehicleIsStillInAir() {
            bool ifVehicleIsStillInAir = Time.time < _jumpTime;

            if (ifVehicleIsStillInAir) {
                _isJumping = true;
                tireRigidbody2D.velocity = new Vector2(_playerHorizontalJumpSpeed, playerParams.jumpHeightAccelerate);
            }
            else _isJumping = false;
        }

        private void SpeedUp() {
            bool isSlowerThanMaxSpeed = _playerSpeed <= _maxSpeed;

            if (Input.GetKey(_speedUpKey) && isSlowerThanMaxSpeed) {
                _playerSpeed += Time.deltaTime * _speedStep;
                _isAnyButtonPressed = false;
            }

            if (Input.GetKeyUp(_speedUpKey)) _isAnyButtonPressed = true;
        }

        private void SlowDown() {
            bool ifFasterThanMinimalSpeed = _playerSpeed >= _minSpeed;

            if (Input.GetKey(_slowDownKey) && ifFasterThanMinimalSpeed) {
                Debug.Log($"min speed: {_playerSpeed}");
                _playerSpeed -= Time.deltaTime * _speedStep;
                _isAnyButtonPressed = false;
            }

            if (Input.GetKeyUp(_slowDownKey)) _isAnyButtonPressed = true;
        }

        private void MoveForward() {
            if (_isJumping == false) tireRigidbody2D.velocity = new Vector2(_playerSpeed * Time.deltaTime, _pos);
        }

        private void BackToNormalSpeed() {
            if (Math.Abs(_playerSpeed - playerParams.playerSpeed) < _speedTolerance && _isAnyButtonPressed) {
                if (_playerSpeed < playerParams.playerSpeed) {
                    _playerSpeed += Time.deltaTime * _speedStep;
                }
                else if (_playerSpeed > playerParams.playerSpeed) {
                    _playerSpeed -= Time.deltaTime * _speedStep;
                }
            }
        }
    }
}