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

        private bool _isJumping, _isAnyButtonPressed;

        private float
            _jumpTime,
            _pos,
            _playerSpeed,
            _minSpeed,
            _maxSpeed,
            _speedStep,
            _playerHorizontalJumpSpeed;

        private KeyCode _slowDownKey, _speedUpKey, _jumpKey;

        // SpeedTolerance is for tolerance which is used to calculate differences
        // between normal vehicle speed and deviation min / max speed
        private float _speedTolerance;

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

            _isJumping = false;

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
            var ifPressedJumpAndReadyToJump =
                Input.GetKeyDown(_jumpKey) && Time.time > _jumpTime + playerParams.jumpTimeInAir;

            if (ifPressedJumpAndReadyToJump) {
                _jumpTime = Time.time + playerParams.jumpTimeInAir;
                FindObjectOfType<AudioManager>().Play("Jump");
            }

            CheckIfVehicleIsStillInAir();
        }

        private void CheckIfVehicleIsStillInAir() {
            var ifVehicleIsStillInAir = Time.time < _jumpTime;

            if (ifVehicleIsStillInAir) {
                _isJumping = true;
                tireRigidbody2D.velocity = new Vector2(_playerHorizontalJumpSpeed + 100 * Time.deltaTime,
                    playerParams.jumpHeightAccelerate);
            }
            else {
                _isJumping = false;
            }
        }

        private void SpeedUp() {
            var isSlowerThanMaxSpeed = _playerSpeed <= _maxSpeed;

            if (Input.GetKey(_speedUpKey) && isSlowerThanMaxSpeed) {
                Debug.Log($"Speeding up: {_playerSpeed}");
                _playerSpeed += Time.deltaTime * _speedStep;
                _isAnyButtonPressed = false;
            }

            if (Input.GetKeyUp(_speedUpKey)) _isAnyButtonPressed = true;
        }

        private void SlowDown() {
            var ifFasterThanMinimalSpeed = _playerSpeed >= _minSpeed;

            if (Input.GetKey(_slowDownKey) && ifFasterThanMinimalSpeed) {
                Debug.Log($"Slowing down: {_playerSpeed}");
                _playerSpeed -= Time.deltaTime * _speedStep;
                _isAnyButtonPressed = false;
            }

            if (Input.GetKeyUp(_slowDownKey)) _isAnyButtonPressed = true;
        }

        private void MoveForward() {
            if (_isJumping == false)
                tireRigidbody2D.velocity = new Vector2(_playerSpeed + 100 * Time.deltaTime, _pos);
        }

        private void BackToNormalSpeed() {
            var whenSpeedIsHigherThanStandard = _playerSpeed > playerParams.playerSpeed;
            var whenSpeedIsLowerThanStandard = _playerSpeed < playerParams.playerSpeed;

            var whenSpeedIsNotStandard = Math.Abs(_playerSpeed - playerParams.playerSpeed) < _speedTolerance;

            if (whenSpeedIsNotStandard && _isAnyButtonPressed) {
                if (whenSpeedIsLowerThanStandard) {
                    if (Math.Abs(_playerSpeed - playerParams.playerSpeed) < 0.1f) return;
                    Debug.Log($"Speed is lower than standard - speeding up: {_playerSpeed}");
                    _playerSpeed += Time.deltaTime * _speedStep;
                }
                else if (whenSpeedIsHigherThanStandard) {
                    if (Math.Abs(_playerSpeed - Time.deltaTime * _speedStep) < 0.2f) return;

                    Debug.Log($"Speed is higher than standard - slowing down: {_playerSpeed}");
                    _playerSpeed -= Time.deltaTime * _speedStep;
                }
            }
        }
    }
}