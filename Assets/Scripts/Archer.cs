using System;
using System.Collections.Generic;
using UnityEngine;
using Core.ControlSystem;

public class Archer : Hero
{
    protected override void Move()
    {
        base.Move();
        /*if (!imLeader && !canMoveAsAllie)
        {
            anim.SetTrigger("reset");
            return;
        }*/
        if (ImLeader)
        {
            anim.SetFloat("move", Mathf.Abs(ControlSystem.Axis.magnitude));
        }
    }

    new void Update()
    {
        base.Update();

        if (ControlSystem.Attack1)
        {
            anim.SetTrigger("attack");
        }
    }
}

