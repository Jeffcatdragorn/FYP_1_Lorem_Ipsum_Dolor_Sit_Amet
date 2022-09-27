using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 1f;
    private float distance;
    private float randY;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randY = Random.Range(2, 13);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, randY , transform.position.z);
        //distance = Vector3.Distance(transform.position, player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
