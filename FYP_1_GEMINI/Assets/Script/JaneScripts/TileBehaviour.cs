using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public int type;
    public bool isConnectedTile;
    public bool playerTouched = false;
    public static bool startBreakable = false;
    [SerializeField] float breakingTimeCounter;

    private void OnCollisionEnter(Collision collision)
    {
        if (type == 2 && isConnectedTile == true && startBreakable == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerTouched = true;
            }
        }
    }


    private void Update()
    {
        if (playerTouched == true)
         SetBreakingTime();

        if(breakingTimeCounter <= 0)
            Destroy(gameObject);
    }

    void SetBreakingTime()
    {
        if (breakingTimeCounter > 0)
        {
            breakingTimeCounter -= Time.deltaTime;
        }

        if (breakingTimeCounter <= 0)
        {
            breakingTimeCounter = 0.0f;
        }
    }
}
