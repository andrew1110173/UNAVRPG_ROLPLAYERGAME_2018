using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_WhiteMage : StateMachineBehaviour
{
    AttackWhiteMage attackWhiteMage;
    bool attackOnce = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (Hero h in GameManager.instance.PartySystem.Party)
        {
            if (h.GetComponent<AttackWhiteMage>())
            {
                attackWhiteMage = h.GetComponent<AttackWhiteMage>();
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackWhiteMage)
        {
            if (stateInfo.normalizedTime > 0.3f && attackOnce)
            {
                attackOnce = false;
                Instantiate(Resources.Load("RayBall", typeof(GameObject)), attackWhiteMage.SpellPoint.position, attackWhiteMage.SpellPoint.rotation);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackOnce = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
