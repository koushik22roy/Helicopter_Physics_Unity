//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField] private List<Base_Heli_Camera> cameras = new List<Base_Heli_Camera>();
    private int camIdx = 0;
    private int startIdx = 1;

    private void Start()
    {
        cameras = transform.GetComponentsInChildren<Base_Heli_Camera>().ToList<Base_Heli_Camera>();
        camIdx = startIdx;
        SwitchCamera(camIdx);
    }

    public void SwitchCamera()
    {
        camIdx++;
        HandleSwitch();
    }

    public void SwitchCamera(int idx)
    {
        HandleSwitch();
    }

    private void HandleSwitch()
    {
        if (camIdx == cameras.Count)
        {
            camIdx = 0;
        }

        for (int i = 0; i < cameras.Count; i++)
        {
            //cameras[i].gameObject.SetActive(false);

            Camera currCam = cameras[i].GetComponent<Camera>();
            if (currCam)
            {
                currCam.enabled = false;
                if (i == camIdx)
                {
                    currCam.enabled = true;
                }
            }
        }
    }
}
