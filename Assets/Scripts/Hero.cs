using System;
using UnityEngine;
using Core.ControlSystem;

public abstract class Hero : Character
{
    [SerializeField]
    protected string lore;
    [SerializeField]
    protected Sprite icon;

    protected override void Move()
    {
        //base.Move();

        //anim.SetFloat("move", Mathf.Abs(GameInputs.Axis.magnitude));

        //transform.Translate(Vector3.forward * GameInputs.Axis.magnitude * speed * Time.deltaTime * multiplierSpeed);

        /*if (GameInputs.Axis != Vector2.zero && !attacking)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(GameInputs.Axis.x, 0f, GameInputs.Axis.y));
        }*/
        grounding = groundSystem.CheckGround(transform);
        transform.Translate(Vector3.forward * ControlSystem.Axis.magnitude * speed * Time.deltaTime);
        
        if(ControlSystem.Axis != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(ControlSystem.Axis.x, 0f, ControlSystem.Axis.y));
        }
    }

    protected override void Jump()
    {
        jumping = ControlSystem.Jump & grounding;
        if (jumping){ rb.AddForce(Vector3.up * (jumping ? JumpForce : 0), ForceMode.Impulse); }
    }

    protected override void Fire_Atack()
    {
        magic_atack= (ControlSystem.FireAtack) ? true : false;
    }

    //[SerializeField]
    //Inventory inventory;

    protected override void Recover(int health)
    {
        base.Recover(health);
    }


}

