using UnityEngine.UI;
using UnityEngine;

public class DetectiveSolution : MonoBehaviour
{
    InteractWithObjects input;
    public GameObject door;
    private int inputCount = 0;
    private bool inputChecker;
    public Animator doorAnimator;
    public bool grappleCheck = false;
    public bool keyCheck = true;
    public Transform doorHandle, player;

    [SerializeField] HumanoidLandInput controllerInput;

    [SerializeField] GameObject pullSlider;

    //private void Update()
    //{
        //Debug.Log("inputCount = " + inputCount);
    //}

    public void OpenDoorWithShooting(bool check) //grappling door & pulling it open
    {
        if (check == true)
        {
            doorAnimator.enabled = false;

            if (inputCount == 7) //if press 7 times already then stop opening the door
            {
                inputCount = 7;
                door.transform.position = new Vector3(0.0f, 0.0f, 7.0f);
            }

            else if (inputCount < 7 && controllerInput.OpenDoorIsPressed && keyCheck == false && doorHandle.localPosition.z < player.localPosition.z)
            {
                inputCount++;
                pullSlider.GetComponent<Slider>().value += 1.0f / 7.0f;

                keyCheck = true;
                //door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + 1.0f);
            }

            else if(controllerInput.OpenDoorIsPressed == false)
            {
                keyCheck = false;
            }

            if (doorHandle.localPosition.z < player.localPosition.z)
            {
                pullSlider.SetActive(true);
            }

            else
            {
                inputCount = 0;
                pullSlider.GetComponent<Slider>().value = 0.0f;
                pullSlider.SetActive(false);
            }
        }

        else if(check == false)
        {
            if(inputCount != 7)
                doorAnimator.enabled = true;
            pullSlider.SetActive(false);

        }
    }
}
