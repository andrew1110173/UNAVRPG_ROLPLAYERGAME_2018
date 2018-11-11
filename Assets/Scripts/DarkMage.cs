using System;
using UnityEngine;
using Core.ControlSystem;

public class DarkMage : Mage
{
    protected override void Move()
    {
        base.Move();
        anim.SetFloat("move", Mathf.Abs(ControlSystem.Axis.magnitude));
    }

    protected override void Jump()
    {
        base.Jump();
        anim.SetBool("Grounding", grounding);

        if (jumping)
        {
            anim.SetTrigger("Jumping");
            jumping = false;
        }
    }

    protected override void Fire_Atack()
    {
        base.Fire_Atack();
        if(magic_atack)
        {
            anim.SetTrigger("FireAtack");
        }
    }
}

