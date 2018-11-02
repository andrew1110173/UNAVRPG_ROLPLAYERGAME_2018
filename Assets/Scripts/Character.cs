using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControlSystem;
using Core.GroundSystem;

public abstract class Character : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody rb;

    [SerializeField]
    protected int health = 5;
    [SerializeField]
    protected int maxHalth = 10;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float JumpForce;
    protected bool jumping;
    protected bool magic_atack;

    [SerializeField]
    protected GroundSystem groundSystem;
    protected bool grounding;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        Move();
        Jump();
    }

    protected void Update()
    {
        Fire_Atack();
    }

    protected virtual void Move()
    {
        ControlSystem.Move(transform, speed);
    }

    protected virtual void Jump(){}

    protected virtual void Fire_Atack()
    {

    }

    protected virtual void Recover(int health)
    {
        this.health +=  this.health + health <= maxHalth  ? health : this.health - maxHalth;
    }

    protected virtual void OnDrawGizmos()
    {
        groundSystem.DrawRay(transform);
    }
}
