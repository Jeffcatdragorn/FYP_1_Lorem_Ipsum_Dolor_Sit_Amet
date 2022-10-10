using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class ParisiteWall : MonoBehaviour
{
    public Animator wallAnimator;
    private AnimatorStateInfo animWallStateInfo;
    private float wallNTime;

    private void Awake()
    {
        wallAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (wallAnimator.GetCurrentAnimatorStateInfo(0).IsName("ParasiticWallDeath"))
        {
            animWallStateInfo = wallAnimator.GetCurrentAnimatorStateInfo(0);
            wallNTime = animWallStateInfo.normalizedTime;
        }

        if (wallNTime > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void destroyedHeart()
    {
        wallAnimator.SetTrigger("Dead");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Dmg Player");
        }
    }
}
