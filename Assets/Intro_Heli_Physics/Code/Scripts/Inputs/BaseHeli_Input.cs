//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BaseHeli_Input : MonoBehaviour
{
    #region Variable
    private float vertical;
    private float horizontal;
    private float throttle;
    private float collective;
    private float pedal;
    private bool cam;
    #endregion

    [SerializeField] private GameInput gameInput;
    private void Update()
    {
        HandleInput();
    }

    protected virtual void HandleInput()
    {
    }

    protected float VerticalInputValue()
    {
        vertical = gameInput.GetMovementVectorNormalized().y;
        return vertical;
    }
    protected float HorizontalInputValue()
    {
        horizontal = gameInput.GetMovementVectorNormalized().x;
        return horizontal;
    }

    protected float ThrottleInputValue()
    {
        throttle = gameInput.GetThrottleVectorNormalized().x;
        return throttle;
    }

    protected float CollectiveInputValue()
    {
        collective = gameInput.GetCollectiveVectorNormalized().y;
        return collective;
    }

    protected float PedalInputValue()
    {
        pedal = gameInput.GetPedalVectorNormalized().x;
        return pedal;
    }

    protected bool CameraSwitchBoolValue()
    {
        return cam = gameInput.CameraSwitch();
    }

    public GameInput GetGameInput()
    {
        return gameInput;
    }
}
