using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Tail_Rotor : MonoBehaviour,IHeliRotor
{
    [Header("Main Rotor Properties")]
    [SerializeField] private Transform lRotor;
    [SerializeField] private Transform rRotor;
    [SerializeField] private float maxPitch = 45f;
    [SerializeField] private float rotationSpeedModifier = 1.5f;

    public void UpdateRotor(float dps, Input_Controllers input)
    {
        transform.Rotate(Vector3.right, dps * rotationSpeedModifier);

        if (lRotor && rRotor)
        {
            lRotor.localRotation = Quaternion.Euler(0,input.PedalInput * maxPitch, 0f);
            rRotor.localRotation = Quaternion.Euler(0,-input.PedalInput * maxPitch, 0f);
        }
    }
}
