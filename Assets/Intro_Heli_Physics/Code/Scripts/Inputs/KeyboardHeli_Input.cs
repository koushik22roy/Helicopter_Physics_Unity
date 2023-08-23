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

    [Header("Camera Properties")]
    private KeyCode camButton;

    #region Properties
    public float ThrottleInput { get { return throttleInput; } private set { } }
    public float CollectiveInput { get { return collectiveInput; } private set { } }
    public Vector2 CyclicInput { get { return cyclicInput; } private set { } }
    public float PedalInput { get { return pedalInput; } private set { } }


    private float stickyThrottle;
    public float StickyThrottleInput { get { return stickyThrottle; } private set { } }
    private float stickyCollective;
    public float StickyCollectiveleInput { get { return stickyCollective; } private set { } }
    
    protected bool camInput = false;
    public bool CamInput { get { return camInput; } private set { } }
    #endregion

    protected override void HandleInput()
    {
        base.HandleInput();

        HandleThrottle();
        HandleCollective();
        HandleCyclic();
        HandlePedal();
        HandleCamButton();

        HandleStickyThrottle();
        HandleStickyCollective();
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
    private void HandleCamButton()
    {
        camInput = CameraSwitchBoolValue();
    }


    ////utility function 
    private void HandleStickyThrottle()
    {
        stickyThrottle += throttleInput * (Time.deltaTime);
        stickyThrottle = Mathf.Clamp01(stickyThrottle);
    }

    private void HandleStickyCollective()
    {
        stickyCollective += collectiveInput * Time.deltaTime;
        stickyCollective = Mathf.Clamp01(stickyCollective);
    }

}
