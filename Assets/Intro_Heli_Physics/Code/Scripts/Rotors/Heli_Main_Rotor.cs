using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Main_Rotor : MonoBehaviour,IHeliRotor
{
    [Header("Main Rotor Properties")]
    [SerializeField] private Transform lRotor;
    [SerializeField] private Transform rRotor;
    [SerializeField] private float maxPitch = 35f;

    public void UpdateRotor(float dps, Input_Controllers input)
    {
        transform.Rotate(Vector3.up, dps);

        if(lRotor && rRotor)
        {
            lRotor.localRotation = Quaternion.Euler(input.CollectiveInput * maxPitch, 0f, 0f);
            rRotor.localRotation = Quaternion.Euler(-input.CollectiveInput * maxPitch, 0f, 0f);
        }
    }
}
