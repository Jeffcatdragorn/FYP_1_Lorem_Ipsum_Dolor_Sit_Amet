using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmPatrol : SwarmBaseStates
{
    float timetoSwitch;
    float wallAvoided;
    Vector3 wanderLocation;
    Rigidbody swarmRB;
    public Vector3 movementVelo;
    public Vector3 wallsPos;
    private Quaternion lookRotation = Quaternion.identity;
    Vector3 finalMovement = Vector3.zero;

    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Enter Patrol");
    }

    public override void UpdateState(SwarmStates states)
    { 
        FaceDirectionState(states); 
    }

    public override void UpdatePhysicsState(SwarmStates states)
    {
        PatrollingState(states);    
    }

    public override void OnCollisionEnter(SwarmStates states)
    {
    }

    public override void OnTriggerEnter(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            states.SwitchStates(states.ChaseState);
        }
        /*else if (other.CompareTag("Walls"))
        {
            wallsPos = other.transform.localPosition;
            wallsPos.y = 0.0f;
            states.SwitchStates(states.AvoidState);
        }*/
    }

    public override void OnTriggerStay(SwarmStates states, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            states.SwitchStates(states.ChaseState);
        }
        else if (other.CompareTag("Walls"))
        {
            //wallsPos = other.transform.TransformPoint(other.transform.position);
            wallsPos = other.transform.localPosition;
            wallsPos.y = 0.0f;
            //states.SwitchStates(states.AvoidState);
        }
    }
    public override void OnTriggerExit(SwarmStates states, Collider collider)
    {
    }

    #region Patrolling Function
    public Vector3 RandomizeLocation(SwarmStates states)
    {
       
        movementVelo = Vector3.zero;

        float PatrolRadius = 5.0f;
        Vector3 centerofSphere = states.initSwarmPos;
        Vector3 randomVec = centerofSphere + Random.insideUnitSphere * PatrolRadius;

        //Debug.DrawLine(randomVec - Vector3.forward * 0.01f,randomVec + Vector3.forward * 0.01f , Color.green, 50.0f);
        //Debug.DrawLine(randomVec - Vector3.right * 0.01f,randomVec + Vector3.right * 0.01f , Color.green, 50.0f);
        Vector3 currentSwarmPos = states.swarmPos;
        //randomVec *=PatrolRadius;
        //wanderLocation = currentSwarmPos + states.transform.forward + randomVec;
        //check
        if(Vector3.Distance(currentSwarmPos, wanderLocation) <= 0.5)
        {
            states.SwitchStates(states.IdleState);//speed
            movementVelo = Vector3.zero;
        }
        else
        {
            movementVelo = randomVec;
            movementVelo.y = 0.0f;
        }
        
        return movementVelo;
    }

    public void PatrollingState(SwarmStates states)
    {
        if (timetoSwitch > states.switchPatrolLocation) //switch after every 3 seconds
        {
            //states.SwitchStates(states.IdleState);
            finalMovement = RandomizeLocation(states);
            timetoSwitch = 0.0f;
        }
        timetoSwitch += (Time.deltaTime);
        //--------------------------------------------------

        //Debug.Log("Final Movement = " + finalMovement);
        states.rb.AddForce((finalMovement - states.swarmPos).normalized * 40.0f, ForceMode.Impulse);
        //states.rb.AddForce((movementVelo).normalized * 100.0f, ForceMode.Impulse);
        //Quaternion lookRotation = Quaternion.LookRotation(states.swarmPos - movementVelo);// GET ROTATION ANGLE
        //states.transform.rotation = Quaternion.RotateTowards(states.transform.rotation, lookRotation, timetoSwitch); // ROTATE FACE NEW DIRECTION 
        //states.transform.rotation = Quaternion.Euler(states.swarmPos - movementVelo);       
    }

    public void FaceDirectionState(SwarmStates states)
    {
            //Debug.Log("Angle more than");
            lookRotation = Quaternion.LookRotation((finalMovement - states.swarmPos).normalized);// GET ROTATION ANGLE
            lookRotation.x = lookRotation.z = 0.0f;
            states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
 /*       }
        else
        {
            Debug.Log("Angle less than");
            lookRotation = Quaternion.identity;
            states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
            // ROTATE FACE NEW DIRECTION 
        }*/
        //states.transform.rotation = Quaternion.Euler(states.swarmPos - movementVelo); 
    }
    #endregion
}
