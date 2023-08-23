using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Camera : Base_Heli_Camera, IHeli_Camera
{
    [Header("Camera Properties")]
    private readonly float _height = 2f;
    private readonly float _distance = 10f;
    private readonly float _smoothSpeed = 0.35f;

    private void Start()
    {
        updateEvent.AddListener(UpdateCamera);
    }

    private void OnDisable()
    {
        updateEvent.RemoveListener(UpdateCamera);
    }

    #region Interface
    public void UpdateCamera()
    {
        wantedPos = rb.position + (targetFlatFwd * _distance) + (Vector3.up * _height);

        transform.position = Vector3.SmoothDamp(transform.position,wantedPos,ref refVelocity,_smoothSpeed);
        transform.LookAt(lookAtTarget);
    }
    #endregion
}
