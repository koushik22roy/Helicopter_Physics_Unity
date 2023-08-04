using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHeli_Input : BaseHeli_Input
{
    #region Variable
    [Header("HeliCopter KeyBoard Inputs Value")]
    [Space(10)]
    [HideInInspector][SerializeField] private float throttleInput = 0f;
    [HideInInspector][SerializeField] private float collectiveInput = 0f;
    [HideInInspector][SerializeField] private Vector2 cyclicInput = Vector2.zero;
    [HideInInspector][SerializeField] private float pedalInput = 0f;
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

        HandleThrottle();
        HandleCollective();
        HandleCyclic();
        HandlePedal();
    }

    private void HandleThrottle() 
    {
        throttleInput = ThrottleInputValue();
    }
    private void HandleCollective() 
    {
        collectiveInput = CollectiveInputValue();
    }
    private void HandleCyclic() 
    {
        cyclicInput.y = VerticalInputValue();
        cyclicInput.x = HorizontalInputValue();
    }
    private void HandlePedal() 
    {
        pedalInput = PedalInputValue();
    }
}
