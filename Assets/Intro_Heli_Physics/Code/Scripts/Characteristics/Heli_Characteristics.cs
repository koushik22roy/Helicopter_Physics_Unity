using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Characteristics : MonoBehaviour
{
    [Header("Lift Properties")]
    private float maxLiftForce = 10f;
    [SerializeField] private Heli_Main_Rotor main_Rotor;

    public void UpdateCharacteristics(Rigidbody rb, Input_Controllers input)
    {
        HandleLift(rb,input);
        HandleCyclic(rb, input);
        HandlePedals(rb, input);
    }

    protected virtual void HandleLift(Rigidbody rb, Input_Controllers input)
    {
        //Debug.Log("Handling Lift");
        Vector3 liftForce = transform.up * (Physics.gravity.magnitude + maxLiftForce) * rb.mass;
        float normalizedRPM = main_Rotor.CurrentRPMs / 500f;
        rb.AddForce(liftForce * Mathf.Pow(normalizedRPM,2f) * Mathf.Pow(input.StickyCollective,2f), ForceMode.Force);
    }

    protected virtual void HandleCyclic(Rigidbody rb, Input_Controllers input)
    {
        //Debug.Log("Handling Cyclic");
    }

    protected virtual void HandlePedals(Rigidbody rb, Input_Controllers input)
    {
        //Debug.Log("Handling Pedals");
    }
}
