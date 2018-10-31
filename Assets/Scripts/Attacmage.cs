using UnityEngine;
using System;
using Core.ControlSystem;
 public class Attacmage : Mage
{
    public void Move()
    {
        base.Move();
        anim.SetFloat("move", Math.Abs(ControlSystem.Axis.magnitude));
    }
}