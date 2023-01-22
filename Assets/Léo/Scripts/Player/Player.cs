using System;
using UnityEngine;

public abstract class Player : MonoBehaviour {
    private int maxHP;
    private int currentHP;
    public int damage;
    public int JumpCount;
    public bool IsAttacking;
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    public abstract void Attack();
    public abstract void TakeDamage();
    public abstract void Die();
    public abstract void Transform();
    public abstract void ThrowPower();
}