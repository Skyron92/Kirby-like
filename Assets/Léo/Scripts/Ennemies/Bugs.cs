using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public abstract class Bugs : MonoBehaviour
{
    [HideInInspector] public float HP;
    [Range(1,100)] public float MaxHP;
    [Range(1,100)] public float Speed;
    [Range(1,100)] public float Strenght;
    [Range(1,100)] public float RangeOfView;
    public static Transform playerTransform;
    public float distance => Vector3.Distance(transform.position, playerTransform.position);
    public float Gravity;
    public BugState CurrentState;

    private void Awake() {
        HP = MaxHP;
        playerTransform = PlayerInput.trans;
    }

    private void Update()
    {
        CurrentState.Transition();
        CurrentState.Do();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RangeOfView);
    }
}