using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private bool _isGrounded;
    [Range(0, 100)] public float Speed;
    [Range(0, 100)] public float JumpSpeed;
    private float gravity = 9.81f; 
    [SerializeField] private GameObject NormalForm;
    [SerializeField] private GameObject FireForm;
    [SerializeField] private GameObject WaterForm;
    [SerializeField] private GameObject RockForm;
    [SerializeField] private GameObject WindForm;
    [SerializeField] private GameObject ThunderForm;
    public static int FormIndex;
   
    void Start() {
        _characterController = GetComponent<CharacterController>();
        _isGrounded = _characterController.isGrounded;
    }
    
    void Update() {
        MovePlayer();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bug")) {
            Bug target = other.GetComponent<Bug>();
            Type type = target.GetType();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void MovePlayer() {
        Vector3 move = new Vector3();
        if (Input.GetButton("Horizontal")) {
            move += new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime,0,0);
        }
        if (Input.GetButtonDown("Jump") && _isGrounded) {
            move += new Vector3(0,JumpSpeed * Time.deltaTime,0);
        }
        _characterController.Move(move);
        _characterController.Move(Vector3.down * gravity);
    }

    void ChangeForm(){
        switch (FormIndex) {
            case 0 :
                Instantiate(NormalForm, transform);
                break;
        }
    }
}