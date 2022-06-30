using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    Animator anim;
    public Transform target;
    public Collider attackCollider_chargeAttack;
    [SerializeField] Transform[] patrol_points;
    int arrayNum;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void walking()
    {
        Debug.Log("caled walking");
        float speed = 1.0f;
        float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, patrol_points[arrayNum].transform.position, step);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, patrol_points[arrayNum].transform.position);
        if (distance < 1)
        {
            arrayNum++;
            if (arrayNum >= patrol_points.Length)
            {
                arrayNum = 0;
            }
        }
    }
    public void AttackColliderT()
    {
        attackCollider_chargeAttack.enabled = true;
        Debug.Log(attackCollider_chargeAttack.enabled + " = attackCollider");
    }
    public void AttackColliderF()
    {
        attackCollider_chargeAttack.enabled = false;
        Debug.Log(attackCollider_chargeAttack.enabled + " = attackCollider");
    }
}

