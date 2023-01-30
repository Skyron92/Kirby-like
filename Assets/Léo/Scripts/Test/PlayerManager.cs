using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private CharacterController _characterController;
    private bool _isGrounded => _characterController.isGrounded;
    [Range(0, 100)] public float Speed;
    [Range(0, 100)] public float JumpSpeed;
    private Vector3 move = new Vector3();
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 1f;
    private Animator _animator;
    private GameObject _prefab;
    [SerializeField] private Form CurrentForm;
    public static int FormIndex;
    

    void Awake() {
        _characterController = GetComponent<CharacterController>();
        CurrentForm = new Normal(this);
        _prefab = CurrentForm.Prefab;
        _animator = GetComponent<Animator>();
    }
    
    void Update() {
        MovePlayer();
        JumpPlayer();
        ApplyGravity();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bug")) {
            Bug target = other.GetComponent<Bug>();
            Type type = target.GetType();
        }
    }

    void MovePlayer() {
        move.x += Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime;
        _characterController.Move(move);
        if(!_isGrounded) _characterController.Move(Vector3.down * gravity * Time.deltaTime);
    }

    void Jump(InputAction.CallbackContext context) {
        if(!context.started) return;
        if (!_isGrounded) return;
        move.y += JumpSpeed * Time.deltaTime;
    }
    
    void JumpPlayer() {
        if(!Input.GetButtonDown("Jump")) return;
        if (!_isGrounded) return;
        move.y += JumpSpeed;
    }
    
    void ApplyGravity() {
        if (_isGrounded) return;
        move.y += gravity * gravityMultiplier * Time.deltaTime;
    }

    private void SwitchForm(Form newForm) {
        CurrentForm = newForm;
        _prefab = CurrentForm.Prefab;
        _animator = CurrentForm._animator;
        Instantiate(_prefab, transform);
    }
    
}