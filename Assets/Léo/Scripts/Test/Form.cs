using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Form : MonoBehaviour {
    private int maxHP;
    private int currentHP;
    public GameObject Prefab;
    [SerializeField] private int Damage;
    [SerializeField] private int JumpCount;
    public bool IsAttacking;
    public Animator _animator;
    protected PlayerManager Player;

    protected Form(PlayerManager playerManager) {
        Player = playerManager;
    }

    private void Awake() {
        _animator = GetComponent<Animator>();
        Prefab = gameObject;
    }

    public abstract void Attack();
    public abstract void TakeDamage();
    public abstract void Die();
    public abstract void Transform();
    public abstract void ThrowPower();
}