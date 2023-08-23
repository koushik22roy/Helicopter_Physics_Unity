using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Heli_Camera : Base_Heli_Camera,IHeli_Camera
{
    #region Variables
    [Header("Basic Camera Properties")]
    public float height = 2f;
    public float distance = 2f;
    public float smoothSpeed = 0.35f;
    #endregion

    #region builtin Methods
    private void OnEnable()
    {
        updateEvent.AddListener(UpdateCamera);
    }

    void OnDisable()
    {
        updateEvent.RemoveListener(UpdateCamera);
    }
    #endregion

    #region Interface Methods
    public void UpdateCamera()
    {
        //wanted position
        wantedPos = rb.position + (targetFlatFwd * distance) + (Vector3.up * height);

        //lets position the camera
        transform.position = Vector3.SmoothDamp(transform.position, wantedPos, ref refVelocity, smoothSpeed);
        transform.LookAt(lookAtTarget);
    }
    #endregion
}
