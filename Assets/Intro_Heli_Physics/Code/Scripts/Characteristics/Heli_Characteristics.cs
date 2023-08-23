using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Characteristics : MonoBehaviour
{
    [Header("Lift Properties")]
    private float maxLiftForce = 10f;
    [SerializeField] private Heli_Main_Rotor main_Rotor;
    private Heli_Controllers heliControl;
    [Space]

    [Header("Tail Rotor Properties")]
    private float tailForce = 2f;
    [Space]

    [Header("Cyclic Properties")]
    private float cyclicForce = 2f;
    private float cyclicForceMultiplier = 1000f;

    [Space]
    [Header("Auto Level Properties")]
    public float AutoLevelForce = 2f;

    private Vector3 _flatForward;
    private float _forwardDot;
    private Vector3 _flatRight;
    private float _rightDot;


    private void Awake()
    {
        heliControl = GetComponent<Heli_Controllers>();
}

    public void UpdateCharacteristics(Rigidbody rb, Input_Controllers inputController)
    {
        HandleLift(rb,inputController);
        HandleCyclic(rb, inputController);
        HandlePedals(rb, inputController);

        CalculateAngles();
        AutoLevel(rb);
    }

    protected virtual void HandleLift(Rigidbody rb, Input_Controllers input)
    {
        Vector3 liftForce = transform.up *
                (UnityEngine.Physics.gravity.magnitude + maxLiftForce) * rb.mass;
        float normalizedRPMs = heliControl.Engines[0].NormalizedRPM;
        liftForce *= Mathf.Pow(input.StickyCollective, 2) * Mathf.Pow(normalizedRPMs, 2f);

        rb.AddForce(liftForce, ForceMode.Force);
    }

    protected virtual void HandleCyclic(Rigidbody rb, Input_Controllers inputController)
    {
        float cyclicXForce = inputController.CyclicInput.x * cyclicForce;
        rb.AddRelativeTorque(Vector3.forward * cyclicXForce, ForceMode.Acceleration);


        float cyclicYForce = -inputController.CyclicInput.y * cyclicForce;
        rb.AddRelativeTorque(Vector3.right * cyclicYForce, ForceMode.Acceleration);

        //apply force based off of the dot product values

        Vector3 forwardVector = _flatForward * _forwardDot;
        Vector3 rightVector = _flatRight * _rightDot;
        Vector3 finalCyclicDir = forwardVector + rightVector;
        finalCyclicDir = Vector3.ClampMagnitude(finalCyclicDir, 1f) *
            cyclicForce * cyclicForceMultiplier;

        Debug.DrawRay(transform.position, finalCyclicDir, Color.green);
        rb.AddForce(finalCyclicDir, ForceMode.Force);
    }

    protected virtual void HandlePedals(Rigidbody rb, Input_Controllers inputController)
    { 
        rb.AddTorque(Vector3.up * inputController.PedalInput * tailForce, ForceMode.Acceleration);
    }


    private void CalculateAngles()
    {
        //calculate flat forward
        _flatForward = transform.forward;
        _flatForward.y = 0f;
        _flatForward = _flatForward.normalized;

        Debug.DrawRay(transform.position, _flatForward, Color.blue);

        //calculate flat right
        _flatRight = transform.right;
        _flatRight.y = 0f;
        _flatRight = _flatRight.normalized;

        Debug.DrawRay(transform.position, _flatRight, Color.red);

        _forwardDot = Vector3.Dot(transform.up, _flatForward);
        _rightDot = Vector3.Dot(transform.up, _flatRight);
    }

    private void AutoLevel(Rigidbody rb)
    {
        float rightForce = -_forwardDot * AutoLevelForce;
        float forwardForce = _rightDot * AutoLevelForce;


        rb.AddRelativeTorque(Vector3.right * rightForce, ForceMode.Acceleration);
        rb.AddRelativeTorque(Vector3.forward * forwardForce, ForceMode.Acceleration);
    }

}
