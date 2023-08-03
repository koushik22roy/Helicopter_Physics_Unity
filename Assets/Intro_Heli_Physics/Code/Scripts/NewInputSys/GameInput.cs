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
        inputVector=inputVector.normalized;
        return inputVector;
    }
}
