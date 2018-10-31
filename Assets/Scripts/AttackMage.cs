using System;
using UnityEngine;
using Core.ControlSystem;

public class AttackMage : Mage
{
    protected override void Move()
    {
        base.Move();
        anim.SetFloat("move", Mathf.Abs(ControlSystem.Axis.magnitude));
    }
}

