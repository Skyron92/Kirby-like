using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player{
    public class PlayerInput : MonoBehaviour {
        
        //Move variables
        private Vector3 _inputMove;
        private Vector3 _direction;
        private CharacterController _characterController;

        //Gravity variables
        private float _gravity = -9.81f;
        private float _velocity;
        private bool _isGrounded => _characterController.isGrounded;
        
        //Jump variables
        private float _jumpCount;
        private bool _isOnAWall;
        private bool _isClimbing;
        private float _grabDuration = 2.0f;

        //Customizable variables
        [Header("Player settings")] [Tooltip("Vitesse de déplacement du joueur")] [Range(0,10)] [SerializeField]
        private float speed;
        [Tooltip("Vitesse de déplacement du joueur sur les murs")] [Range(0,10)] [SerializeField]
        private float Walkspeed;
        [Tooltip("Vitesse à laquelle le joueur tombe")] [Range(0,10)] [SerializeField]
        private float height;
        [Tooltip("Puissance du saut du joueur")] [Range(0,10)] [SerializeField]
        private float jumpForce;
        [Tooltip("Nombre de saut pouvant être effectué une fois en l'air")] [SerializeField]
        private float NumberOfJumps;
        [Tooltip("Forme actuelle du joueur")] [SerializeField]
        private Forme forme;
        
        public enum Forme {
            Normale,
            Flamboyante,
            Aquatique,
            Aérienne,
            Electrique, 
            ArmureDeRoche, 
        }

        private void Awake() {
            _characterController = GetComponent<CharacterController>();
            _isOnAWall = false;
        }

        private void Update() {
            MovePlayer();
            RotatePlayer();
            Gravity();
            if (_isGrounded) _jumpCount = 0;
            DetectWall();
        }

        public void Move(InputAction.CallbackContext context) {
            if (_isOnAWall) return;
            _inputMove = context.ReadValue<Vector2>();
            _direction = new Vector3(_inputMove.x, 0, 0);
        }

        private void MovePlayer() {
            if(!_isOnAWall) _characterController.Move(_direction * speed * Time.deltaTime);
            else _characterController.Move(_direction * Walkspeed * Time.deltaTime);
        }

        private void RotatePlayer() {
            if(_inputMove == Vector3.zero) return;
            float rotationAngle = Vector3.Angle(_direction, Vector3.right);
            if (_direction.x < 0) rotationAngle = -rotationAngle;
            Quaternion rotation = Quaternion.Euler(0,rotationAngle,0);
            if (0 + rotationAngle < 90 && 0 + rotationAngle > -90) rotation.y = 0;
            if (180 - rotationAngle > 90 && 180 - rotationAngle > 180) rotation.y = 180;
            transform.rotation = rotation;
        }

        private void Gravity() {
            if(_isOnAWall) return;
            if (_isGrounded && _velocity < 0.0f) _velocity = -1.0f;
            else _velocity += _gravity * height * Time.deltaTime;
            _direction.y = _velocity;
        }

        public void Jump(InputAction.CallbackContext context) {
            if(!context.started) return;
            if(_isGrounded) _velocity += jumpForce;
            if(forme == Forme.Aérienne) DoubleJump();
        }

        public void DoubleJump() {
            if(_isGrounded) return;
            if(_jumpCount >= NumberOfJumps) return;
            _velocity += jumpForce;
            _jumpCount++;
        }

        public void DetectWall() {
            if(forme == Forme.ArmureDeRoche) return;
            if(_isGrounded) return;
            RaycastHit hit;
            Vector3 side = new Vector3(_direction.x, 0, 0);
            if (Physics.Raycast(transform.position, side, out hit, 1.0f)) {
                if (hit.collider.CompareTag("Wall")) {
                    _isOnAWall = true;
                    _isClimbing = true;
                }
            }
            else _isOnAWall = false;
            if (!_isOnAWall && _isClimbing) {
                _velocity += 2;
                _isClimbing = false;
            }
        }

        public void GrabWall(InputAction.CallbackContext context) {
            if (!context.performed) return;
            if (_isGrounded) {
                _isOnAWall = false;
                return;
            }
            _grabDuration = 2.0f;
            _grabDuration -= Time.deltaTime;
            if (_grabDuration <= 0) _isOnAWall = false;
        }

        public void Climb(InputAction.CallbackContext context) {
            if(!_isOnAWall) return;
            _inputMove = context.ReadValue<Vector2>();
            int fallMultiplier = 1;
            if (_inputMove.y < 0) fallMultiplier = 3;
            else fallMultiplier = 1;
            _direction = new Vector3(0, _inputMove.y * fallMultiplier, 0);
        }

        public void Attack(InputAction.CallbackContext context) {
            if(forme == Forme.ArmureDeRoche) if(!context.started && _isGrounded) return;
                else if (!context.performed)return;
        }
        
    }
}
