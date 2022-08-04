using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class TVTriggerBehaviour : MonoBehaviour
{
    public static bool tvCheck= false;
    public VideoPlayer tvVideo;
    public Transform tvObject;
    public GameObject tvMask;

    private void OnTriggerStay(Collider player)
    {
        if(player.tag == "Player" && tvCheck == true){
            tvMask.SetActive(false);
            tvVideo.Play();
            AudioManager.instance.PlaySound("tvAudio", tvObject.position, true);
        }
    }
}
