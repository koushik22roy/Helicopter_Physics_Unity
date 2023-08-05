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
    public float ThrottleInput { get { return throttleInput; } private set { } }
    public float CollectiveInput { get { return collectiveInput; } private set { } }
    public Vector2 CyclicInput { get { return cyclicInput; } private set { } }
    public float PedalInput { get { return pedalInput; } private set { } }


    private float stickyThrottle;
    public float StickyThrottle { get { return stickyThrottle; } private set { } }
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


    ////utility function 
    //private void HandleStickyThrottle()
    //{
    //    stickyThrottle += throttleInput;
    //    Mathf.Clamp01(stickyThrottle);

    //    Debug.Log("Sticky Throttle" + stickyThrottle);
    //}
}
