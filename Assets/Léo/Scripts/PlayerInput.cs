using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player{
    public class PlayerInput : MonoBehaviour {
        private Vector2 _input;
        private CharacterController _characterController;

        private void Awake() {
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(InputAction.CallbackContext context) {
            _input = context.ReadValue<Vector2>();
            _characterController.Move(_input);
        }
    }
}
