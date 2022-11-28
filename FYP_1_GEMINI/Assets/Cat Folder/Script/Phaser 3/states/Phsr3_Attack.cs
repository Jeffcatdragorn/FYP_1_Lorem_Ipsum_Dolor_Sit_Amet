using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phsr3_Attack : Phsr3_Abstract
{
    Animator anim;
    float timer;
    int randomiser;
    bool doneAttack;
    int patternNum;

    public override void EnterState(Phsr3_Manager Phsr)
    {
        anim = Phsr.GetComponent<Animator>();
        patternNum = 0;
    }
    #region collision and trigggers

    public override void ExitState(Phsr3_Manager phsr)
    {
    }

    public override void OnCollisionEnter(Phsr3_Manager phsr, Collision col)
    {
    }

    public override void OnTriggerEnter(Phsr3_Manager phsr, Collider col)
    {
    }

    public override void OnTriggerStay(Phsr3_Manager phsr, Collider col)
    {
    }

    #endregion
    public override void UpdateState(Phsr3_Manager phsr)
    {
        if (phsr.Alive)
        {
            //phsr.transform.LookAt(phsr.player.transform.position);
            if(doneAttack) timer += Time.deltaTime;
            Phase2(phsr);
            Phase1(phsr);
            DoneAttack(phsr);
        }
    }
    private void Phase1(Phsr3_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if (!doneAttack)
            {
                randomiser = Random.Range(0,4); // 0-3
                // randomise the attack by 1/3 because 50/50 is a bit bias to the first num
                // attack 1 - 33% chance 
                if (randomiser == 1)
                {
                        anim.SetTrigger("Attack 1");
                        doneAttack = true;
                }
                // attack 2 - 66% chance 
                if (randomiser != 1)
                {
                        anim.SetTrigger("Attack 2");
                        doneAttack = true;
                }
            }
        }
    }
    private void Phase2(Phsr3_Manager phsr)
    {
        #region p2
        if (phsr.AliveP2)
        {
            if (!doneAttack)
            {
                if (patternNum <= 2)
                {
                    // attack 1
                    anim.SetTrigger("Attack 1");
                    doneAttack = true;
                    Debug.Log("attack 1 - " + patternNum);
                }
                if (patternNum >= 3 && patternNum < 5)
                {
                    // attack 2
                    anim.SetTrigger("Attack 2"); 
                    doneAttack = true;
                    Debug.Log("attack 2 - " + patternNum);
                }
                if (patternNum == 5)
                {
                    // charge
                    anim.SetBool("Attack 3", true);
                    doneAttack = true;
                    Debug.Log("attack 3 - " + patternNum);
                }
                PatternNumCycle();
            }
        }
        #endregion
    }
    private void PatternNumCycle()
    {
        patternNum += 1;
        Debug.Log(patternNum);
        if (patternNum > 5)
        {
            patternNum = 0;
        }
    }
    private void DoneAttack(Phsr3_Manager phsr)
    {
        if (phsr.AliveP1)
        {
            if (timer > phsr.cdForP1)
            {
                doneAttack = false;
                timer = 0;
            }
        }
        if (phsr.AliveP2)
        {
            if (timer > phsr.cdForP2)
            {
                doneAttack = false;
                timer = 0;
            }
        }
    }
    
}


/* notepad
 * 
 * Attack 1:
 * - 1 power ball at a time 
 * Attack 2:
 * -multiple ball at a time
 * 
 * phase 1:
 * - ball follows last position 
 * - Attack 1 and Attack 2 is random by 50% each
 * - cd after each attack is 2 second
 * 
 * phase 2:
 * - ball follows player for x amount of second
 * - Attack 1 is attacked 3 times
 * - Attack 2 is attacked 2 times
 * - Charged up is followed after Attack 2 is done
 * - cd after each attack is 1 second
 * - cd after Charged up is 4 seconds
 * 
 * balls:
 * - can be shoot
 * - disappears after x amount of second 
 * 
 *
 */