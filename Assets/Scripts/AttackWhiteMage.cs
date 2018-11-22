using System;
using UnityEngine;
using Core.ControlSystem;
using System.Collections;

public class AttackWhiteMage : Mage
{

    [SerializeField]
    Transform spellPoint;

    private bool Attack1Estatus = true;

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

        if (ControlSystem.Attack1 && ImLeader)
        {
            Spell();
        }

        if (ControlSystem.BasicAttack && ImLeader)
        {
            BasicAttack();
        }
    }

    protected override void BasicAttack()
    {
        if (anim.GetFloat("move") == 0)
            anim.SetTrigger("BasicAttack");
    }


    protected override void Spell()
    {
        //Solo se puede disparar cada 3 segundos y se evita la precarga de la habilidad
        if (Attack1Estatus && anim.GetFloat("move") == 0)
        {
            anim.SetTrigger("spell");
            Attack1Estatus = false;
            ChargeSkill();
        }
        Debug.Log("Cargando Habilidad");
    }

    void ChargeSkill()
    {
        StartCoroutine("waitSkill");
    }

    IEnumerator waitSkill()
    {
        yield return new WaitForSeconds(2);
        Attack1Estatus = true;
    }
}
