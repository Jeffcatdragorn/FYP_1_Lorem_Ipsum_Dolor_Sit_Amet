using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIdle : StateMachineBehaviour
{
    float idling_cd = 0;
    float distance;
    Transform player;
    float radius_within_the_player = 4;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        Debug.Log("idling");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idling(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    void idling(Animator animator)
    {
        distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance < radius_within_the_player)
        {
            Debug.Log(distance);
            Debug.Log("im within range to attack");
            animator.SetBool("walk", true);
        }
        else
        {
            if ((idling_cd % 5) < 1)
            {
                Debug.Log("done idling");
                animator.SetBool("walk", true);
            }
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
