using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class ParisiteWall : MonoBehaviour
{
    public Animator deathAnimation;
    public void destroyedHeart()
    {
        deathAnimation.SetTrigger("Dead");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Dmg Player");
        }
    }
}
