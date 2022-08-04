using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDomeBehaviour : MonoBehaviour
{
    public GameObject exitDomeUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            exitDomeUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}
