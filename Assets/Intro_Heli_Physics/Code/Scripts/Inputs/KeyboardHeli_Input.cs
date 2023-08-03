using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHeli_Input : BaseHeli_Input
{
    #region Variable
    [Header("HeliCopter KeyBoard Inputs Value")]
    [Space(10)]
    [SerializeField] private float throttleInput = 0f;
    [SerializeField] private float collectiveInput = 0f;
    [SerializeField] private Vector2 cyclicInput = Vector2.zero;
    [SerializeField] private float pedalInput = 0f;
    #endregion

    #region Properties
    public float ThrottleInput { get { return throttleInput; }}
    public float CollectiveInput { get { return collectiveInput; } }
    public Vector2 CyclicInput { get { return cyclicInput; } }
    public float PedalInput { get { return pedalInput; } }
    #endregion

    protected override void HandleInput()
    {
        base.HandleInput();
        //throttleInput = GetGameInput().GetMovementVectorNormalized().y;
        //pedalInput = GetGameInput().GetMovementVectorNormalized().x;

        HandleThrottle();
        HandleCollective();
        HandleCyclic();
        HandlePedal();
    }

    private void HandleThrottle() { }
    private void HandleCollective() { }
    private void HandleCyclic() 
    {
        cyclicInput.y = VerticalInput();
        cyclicInput.x = HorizontalInput();
    }
    private void HandlePedal() { }
}
