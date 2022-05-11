using UnityEngine;
using UnityEngine.AI;

public class nmyNav : MonoBehaviour
{
    #region patrol with navmesh
    ////Dictates whether the agent waits on each node
    //[SerializeField] bool _patrolWaiting;

    ////The total time we wait at each node
    //[SerializeField] float _totalWaitTime = 3f;

    ////The probability of switching direction
    //[SerializeField] float _switchProbability = 0.2f;

    ////The list of all patrol nodes to visit 
    //[SerializeField] Transform _patrolPoints[]; // you gotta change this to array later

    //NavMeshAgent _navMeshAgent;
    //int _currentPatrolIndex;
    //bool _travelling;
    //bool _waiting;
    //bool _patrolForward;
    //float _waitTimer;

    //void Start()
    //{
    //    _navMeshAgent = this.GetComponent<NavMeshAgent>();

    //    if (_navMeshAgent == null)
    //    {
    //        Debug.Log("The nav mesh agent component is not attacthed to " + gameObject.name);
    //    }
    //    else
    //    {
    //        if (_patrolPoints != null && _patrolPoints.childCount/* find out what is the  count for the end of the list*/ >= 2)
    //        {
    //            _currentPatrolIndex = 0;
    //            SetDestination();
    //        }
    //        else
    //        {
    //            Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
    //        }
    //    }
    //}

    //void Update()
    //{
    //    //check if we're close to the destination
    //    if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
    //    {
    //        _travelling = false;
    //        if (_patrolWaiting)
    //        {
    //            _waiting = true;
    //            _waitTimer = 0f;
    //        }
    //        else
    //        {
    //            ChangePatrolPoint();
    //            SetDestination();
    //        }
    //    }

    //    //Instead if we're waiting
    //    if (_waiting)
    //    {
    //        _waitTimer += Time.deltaTime;
    //        if (_waitTimer >= _totalWaitTime)
    //        {
    //            _waiting = false;

    //            ChangePatrolPoint();
    //            SetDestination();
    //        }
    //    }
    //}

    //private void SetDestination()
    //{
    //    if (_patrolPoints != null)
    //    {
    //        Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position; // u must get the transform from the array. cant use list for now
    //        _navMeshAgent.SetDestination(targetVector);
    //        _travelling = true;
    //    }
    //}

    ///// <summary>
    ///// selects a new patrol point in the available list, but
    ///// also with a small probability allows for us to move forward or backwards.
    ///// </summary>
    //private void ChangePatrolPoint()
    //{
    //    if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
    //    {
    //        _patrolForward = !_patrolForward;
    //    }


    //    if (_patrolForward)
    //    {
    //    /// <summary>
    //    /// here is another way of making the statement below. this is the long way.
    //    ///  _currentPatrolIndex++;
    //    ///  if(_currentPatrolIndex >= _patrolPoints.count)
    //    ///  {
    //    ///     _currentPatrolIndex = 0;
    //    ///  }
    //    /// </summary>
    //        _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.childCount/*gotta change to array later*/;
    //    }
    //    else
    //    {
    //        if (--_currentPatrolIndex < 0)
    //        {
    //            _currentPatrolIndex = _patrolPoints.childCount/*gotta change to arary later*/ - 1;
    //        }
    //    }
    //}
    #endregion

    #region patrol with array and navmesh

    private Animator animPhaser;

    //To store the waypoint
    public Transform[] waypoint;

    //To check the waypoint stored in the element in the waypoint array
    private int waypointIndex;

    //To adjust the speed of the agent to move from one point to another
    public int speed;

    //To check the current distance between the agent and the waypoint
    private float dist;

    //The navmesh agent that will be used for this code
    private NavMeshAgent navmeshAgent;

    void Start()
    {
        //Reset the waypoint and look at to the origin
        waypointIndex = 0;
        transform.LookAt(waypoint[waypointIndex].position);

        navmeshAgent = GetComponent<NavMeshAgent>();

        animPhaser = GetComponent<Animator>();
    }

    void Update()
    {
        //Store the distance between the waypoint and yourself
        dist = Vector3.Distance(transform.position, waypoint[waypointIndex].position);
        Debug.Log(dist);
        //Check if the distance is lesser than the reaching value. 
        if (dist < 1f)
        {
            // if yes, change to next location by inc the index num
            IncreaseIndex();
        }
        // continue patrolling
        Patrol();
    }

    void Patrol()
    {
        #region Move using transform
        //// move forward using transform
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        #endregion

        #region Move using navmesh
        //move towards the waypoint using navmesh
        navmeshAgent.destination = waypoint[waypointIndex].position;
        animPhaser.SetBool("walk", true);
        #endregion
    }

    void IncreaseIndex()
    {
        //Increase the waypointIndex to change to the next location/element stored in the waypoint array
        waypointIndex++;
        //If you exceeded the maximum number of waypoint stored in the array
        if (waypointIndex >= waypoint.Length)
        {
            //Then set the current waypoint back to the first waypoint
            waypointIndex = 0; // reset the loop
        }
        //transform.LookAt(waypoint[waypointIndex].position );
        #region turning slowly , you need a new animation to make it turn properly
        Quaternion targetRotation = Quaternion.identity;
        Quaternion nextRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.rotation = nextRotation;

        GameObject newWaypoint = GameObject.FindWithTag("point");
        Vector3 targetDirection = (newWaypoint.transform.position - transform.position).normalized;
        
        targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime);
        #endregion
    }
    #endregion
}
