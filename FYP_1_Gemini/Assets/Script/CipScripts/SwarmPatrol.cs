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
    private Quaternion lookRotation;
    Vector3 finalMovement = Vector3.zero;

    public override void EnterState(SwarmStates states)
    {
        Debug.Log("Enter Patrol");
        finalMovement = RandomizeLocation(states);
    }

    public override void UpdateState(SwarmStates states)
    { 
        //FaceDirectionState(states);   
        if (timetoSwitch > states.switchPatrolLocation) //switch after every X seconds
        {
            //states.SwitchStates(states.IdleState);
            Debug.Log("Switched Position");
            finalMovement = RandomizeLocation(states);
            //Debug.Log("Final MOvement" + finalMovement);
            timetoSwitch = 0.0f;
        }
        timetoSwitch += (Time.deltaTime);
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
        //Vector3 currentSwarmPos = states.swarmPos;
        //randomVec *=PatrolRadius;
        //wanderLocation = currentSwarmPos + states.transform.forward + randomVec;
        randomVec.y = 0.0f;
        movementVelo = randomVec;
        return movementVelo;
    }

    public void PatrollingState(SwarmStates states)
    {
        //if (timetoSwitch > states.switchPatrolLocation) //switch after every 3 seconds
        //{
            //states.SwitchStates(states.IdleState);
        //    finalMovement = RandomizeLocation(states);
        //    timetoSwitch = 0.0f;
        //}
        //timetoSwitch += (Time.deltaTime);
        //--------------------------------------------------

        //Debug.Log("Final Movement = " + finalMovement);
        if(Vector3.Distance(finalMovement, states.swarmPos) <= 0.01f)
        {
            Debug.Log("Stoppped");
            //states.SwitchStates(states.IdleState);//speed
        }
        else
        {
            Debug.Log("Moving" + finalMovement);
            states.rb.AddForce((finalMovement - states.swarmPos).normalized * 40.0f, ForceMode.Impulse);
            //movementVelo = randomVec;
            //movementVelo.y = 0.0f;
        }
        //states.rb.AddForce((movementVelo).normalized * 100.0f, ForceMode.Impulse);

        //----------Direction-----------
        //Debug.Log("Angle more than");
        //Vector3 movementDir = (finalMovement - states.swarmPos).normalized;
        //lookRotation = Quaternion.LookRotation(finalMovement, Vector3.up);
        //lookRotation = Quaternion.LookRotation(movementDir);// GET ROTATION ANGLE
        //lookRotation.x = lookRotation.z = 0.0f;
        //Debug.Log("Look Rotation: " + lookRotation);
        //states.transform.rotation = Quaternion.RotateTowards(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
        //states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);

    }

    public void FaceDirectionState(SwarmStates states)
    {
    
            //Debug.Log("Angle more than");
            Vector3 movementDir = (finalMovement - states.swarmPos).normalized;
            //lookRotation = Quaternion.LookRotation(finalMovement, Vector3.up);
            lookRotation = Quaternion.LookRotation((movementDir) * Time.deltaTime) ;// GET ROTATION ANGLE
            lookRotation.x = lookRotation.z = 0.0f;
            Debug.Log("Look Rotation: " + lookRotation);
            //states.transform.rotation = Quaternion.RotateTowards(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
            states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
            //states.rb.MoveRotation(states.rb.rotation * lookRotation);

            if(Vector3.Distance(finalMovement, states.swarmPos) <= 0.01f)
            {
                lookRotation = Quaternion.LookRotation((finalMovement.normalized) * Time.fixedDeltaTime);// GET ROTATION ANGLE
                lookRotation.x = lookRotation.z = 0.0f;
                //states.transform.rotation = Quaternion.Slerp(states.transform.rotation, lookRotation, timetoSwitch * Time.deltaTime);
                states.rb.MoveRotation(states.rb.rotation * lookRotation); //Rotating rigidbody
            }
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
