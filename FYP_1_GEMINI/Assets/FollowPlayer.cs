using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 1f;
    private float distance;
    private float randY;
    private Phsr3_Manager phsr;
    private float time;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randY = Random.Range(2, 13);
        phsr = GameObject.FindGameObjectWithTag("Phaser").GetComponent<Phsr3_Manager>();
        AudioManager.instance.PlaySoundParent("phsrBall", this.gameObject, true);
    }
    void Update()
    {
        //Debug.Log("teslaProgress + " + TeslaCoilBehaviour.teslaProgress);
        //Debug.Log("alive1 + " + phsr.AliveP1);
        //Debug.Log("alive2 + " + phsr.AliveP2);
        if (phsr.AliveP1)
        {
            BallLifeSpan(5);
        }
        if (phsr.AliveP2)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, randY, transform.position.z);
            //distance = Vector3.Distance(transform.position, player.position);
            BallLifeSpan(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Phaser"
            && other.tag != "Boobies_ball")
        {
            Destroy(gameObject);
        }
    }
    public void BallLifeSpan(float lifeSpanCount)
    {
        time += Time.deltaTime;
        if (time > lifeSpanCount) Destroy(gameObject);
    }
    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}
