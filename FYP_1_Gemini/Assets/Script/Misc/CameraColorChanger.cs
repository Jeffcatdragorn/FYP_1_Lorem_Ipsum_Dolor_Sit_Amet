using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    private Material thirdPersonCamRenderMaterial;
    private Material firstPersonCamRenderMaterial;
    public Shader thirdPersonCamShader;
    public Shader firstPersonCamShader;
    [SerializeField] CameraController camController;

    // Start is called before the first frame update
    void Awake()
    {
        thirdPersonCamRenderMaterial = new Material(thirdPersonCamShader);
        firstPersonCamRenderMaterial = new Material(firstPersonCamShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (camController.cinemachineFirstPerson.Priority > camController.cinemachineThirdPerson.Priority)
        {
            Graphics.Blit(source, destination, firstPersonCamRenderMaterial);
        }
        else
        {
            Graphics.Blit(source, destination, thirdPersonCamRenderMaterial);
        }
    }
}
