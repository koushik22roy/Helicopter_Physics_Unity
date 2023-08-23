using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base_Heli_Camera : MonoBehaviour
{
    public Rigidbody rb;
    public Transform lookAtTarget;

    protected Vector3 wantedPos;
    protected Vector3 refVelocity;
    protected Vector3 targetFlatFwd;

    protected UnityEvent updateEvent = new UnityEvent();

    private void FixedUpdate()
    {
        if (rb)
        {
            targetFlatFwd = rb.transform.forward;
            targetFlatFwd.y = 0f;
            targetFlatFwd = targetFlatFwd.normalized;

            updateEvent.Invoke();
        }
    }
}
