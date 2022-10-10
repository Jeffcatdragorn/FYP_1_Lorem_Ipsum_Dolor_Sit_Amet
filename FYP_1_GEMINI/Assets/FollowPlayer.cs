using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 1f;
    private float distance;
    private float randY;
    private Phaser2_Manager phsr;
    private float time;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randY = Random.Range(2, 13);
        phsr = GameObject.FindGameObjectWithTag("Phaser").GetComponent<Phaser2_Manager>();
    }
    void Update()
    {
        if (phsr.AliveP1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
            transform.position = new Vector3(transform.position.x, randY , transform.position.z);
            //distance = Vector3.Distance(transform.position, player.position);
        }
        time += Time.deltaTime;
        if (time > 5) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
