using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHeli_Input : MonoBehaviour
{
    #region Variable
    private float vertical;
    private float horizontal;
    #endregion

    [SerializeField] private GameInput gameInput;
    private void Update()
    {
        HandleInput();
    }

    protected virtual void HandleInput()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    }

    public float VerticalInput()
    {
        vertical = gameInput.GetMovementVectorNormalized().y;
        return vertical;
    }
    public float HorizontalInput()
    {
        horizontal = gameInput.GetMovementVectorNormalized().x;
        return horizontal;
    }

    public GameInput GetGameInput()
    {
        return gameInput;
    }
}
