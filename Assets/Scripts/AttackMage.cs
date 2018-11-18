using System;
using UnityEngine;
using Core.ControlSystem;

public class AttackMage : Mage
{

    [SerializeField]
    Transform spellPoint;

    public Transform SpellPoint
    {
        get
        {
            return spellPoint;
        }
    }

    protected override void Move()
    {
        base.Move();
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
            Spell();
        }
    }

    protected override void Spell()
    {
        anim.SetTrigger("spell");
    }
}

