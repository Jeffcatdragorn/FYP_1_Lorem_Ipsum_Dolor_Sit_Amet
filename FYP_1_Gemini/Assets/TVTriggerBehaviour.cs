using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class TVTriggerBehaviour : MonoBehaviour
{
    public static bool tvCheck = false;
    public VideoPlayer tvVideo;
    public Transform tvObject;
    public GameObject tvMask;
    public GameObject tvLight;

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player" && tvCheck == true && Inventory.flashlightObtained == true && TutorialManager.flow == 2){
            tvMask.SetActive(false);
            tvLight.SetActive(true);
            tvVideo.Play();
            AudioManager.instance.PlaySound("tvAudio", tvObject.position, true);
            TutorialManager.flow = 3;
            Destroy(gameObject);
        }
    }
}
