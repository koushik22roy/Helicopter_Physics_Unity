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
    public float StickyThrottleInput { get { return stickyThrottle; } private set { } }
    private float stickyCollective;
    public float StickyCollectiveleInput { get { return stickyCollective; } private set { } }
    #endregion

    protected override void HandleInput()
    {
        base.HandleInput();

        HandleThrottle();
        HandleCollective();
        HandleCyclic();
        HandlePedal();
        HandleStickyThrottle();
        HandleStickyCollective();
    }

    private void HandleThrottle() 
    {
        throttleInput = ThrottleInputValue();
        //throttleInput = Mathf.Clamp01(throttleInput);
        //Debug.Log("Throtle INput : " + throttleInput);
        
    }
    private void HandleCollective() 
    {
        collectiveInput = CollectiveInputValue();
        //collectiveInput = Mathf.Clamp01(collectiveInput);
        //Debug.Log("Collective Input : " + collectiveInput);
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
    private void HandleStickyThrottle()
    {
        stickyThrottle += throttleInput * (Time.deltaTime);
        stickyThrottle = Mathf.Clamp01(stickyThrottle);
        //Debug.Log("Sticky Throtle: "+stickyThrottle);
    }

    private void HandleStickyCollective()
    {
        stickyCollective += collectiveInput * Time.deltaTime;
        stickyCollective = Mathf.Clamp01(stickyCollective);

        //Debug.Log("Sticky Throtle: "+stickyCollective);
    }
}
