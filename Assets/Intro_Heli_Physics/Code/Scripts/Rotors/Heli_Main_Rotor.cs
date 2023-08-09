using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Main_Rotor : MonoBehaviour,IHeliRotor
{
    [Header("Main Rotor Properties")]
    [SerializeField] private Transform lRotor;
    [SerializeField] private Transform rRotor;
    [SerializeField] private float maxPitch = 35f;
    //[SerializeField] private Vector2 cyclicVal;

    private float currentRPM;
    public float CurrentRPMs { get { return currentRPM; } private set { } }

    public void UpdateRotor(float dps, Input_Controllers input)
    {
        //currentRPM = (dps / 360f) * 60f;
        //Debug.Log(currentRPM);

        transform.Rotate(Vector3.up, dps /** Time.deltaTime * 0.5f*/);

        //Vector3 discNormal = Vector3.Normalize(transform.up + new Vector3(-cyclicVal.x,0f,-cyclicVal.y));

        if(lRotor && rRotor)
        {
            //cyclicVal = input.CyclicInput;

            lRotor.localRotation = Quaternion.Euler(input.StickyCollective * maxPitch, 0f, 0f);
            rRotor.localRotation = Quaternion.Euler(-input.StickyCollective * maxPitch, 0f, 0f);
        }
    }
}
