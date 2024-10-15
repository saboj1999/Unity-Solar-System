using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineFreeLook[] freeLookCameras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
    {
        SwitchToCamera(0);
    }
    else if (Input.GetKeyDown("2"))
    {
        SwitchToCamera(1);
    }
    else if (Input.GetKeyDown("3"))
    {
        SwitchToCamera(2);
    }
    else if (Input.GetKeyDown("4"))
    {
        SwitchToCamera(3);
    }
    else if (Input.GetKeyDown("5"))
    {
        SwitchToCamera(4);
    }
    else if (Input.GetKeyDown("6"))
    {
        SwitchToCamera(5);
    }
    else if (Input.GetKeyDown("7"))
    {
        SwitchToCamera(6);
    }
    else if (Input.GetKeyDown("8"))
    {
        SwitchToCamera(7);
    }
    else if (Input.GetKeyDown("9"))
    {
        SwitchToCamera(8);
    }
    else if (Input.GetKeyDown("0"))
    {
        SwitchToCamera(9);
    }
        
    }

    private void SwitchToCamera(int cameraID)
    {
        freeLookCameras[cameraID].Priority = 10;
            
        for(int i = 0; i < freeLookCameras.Length; i++)
        {
            if(i != cameraID)
            {
                freeLookCameras[i].Priority = 0;
            }             
        }
    }
}
