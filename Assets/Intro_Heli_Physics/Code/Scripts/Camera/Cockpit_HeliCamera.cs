using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cockpit_HeliCamera : Base_Heli_Camera, IHeli_Camera
{
    [SerializeField] private Transform cockpitPosition; 

    private void OnEnable()
    {
        updateEvent.AddListener(UpdateCamera);
    }

    private void OnDisable()
    {
        updateEvent.RemoveListener(UpdateCamera); 
    }

    public void UpdateCamera()
    {
        if (cockpitPosition)
        {
            transform.position = cockpitPosition.position;
            transform.LookAt(lookAtTarget);
        }
       
    }
}
