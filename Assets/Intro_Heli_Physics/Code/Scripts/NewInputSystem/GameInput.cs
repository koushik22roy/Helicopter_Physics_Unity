using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Heli_Input inputActions;
    private void Awake()
    {
        inputActions = new Heli_Input();
        inputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    public Vector2 GetThrottleVectorNormalized() 
    {
        Vector2 inputVector = inputActions.Player.Throttle.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector2 GetCollectiveVectorNormalized()
    {
        Vector2 inputVector = inputActions.Player.Collective.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector2 GetPedalVectorNormalized()
    {
        Vector2 inputVector = inputActions.Player.Pedal.ReadValue<Vector2>();
        return inputVector;
    }

    public bool CameraSwitch()
    {
        return inputActions.Player.CameraSwitch.triggered;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
}
