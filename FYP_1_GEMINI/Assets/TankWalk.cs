using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWalk : StateMachineBehaviour
{
    float walkcd = 0;
    Transform player;
    float distance;
    float radius_within_the_player = 4;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("walking");
        player = GameObject.FindWithTag("Player").transform;
        //animator.applyRootMotion = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        walking(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.applyRootMotion = true;
        Debug.Log("done walking");
        walkcd = 0;
    }

    void walking(Animator animator)
    {
        distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance < radius_within_the_player)
        {
            //Debug.Log(distance);
            //Debug.Log("im within range to attack");
            animator.SetTrigger("attack");
        }
        else
        {
            walkcd += Time.deltaTime;
            if (walkcd > 5.0f)
            {
                animator.GetComponent<TankManager>().walking();
                animator.SetBool("walk", false);
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
