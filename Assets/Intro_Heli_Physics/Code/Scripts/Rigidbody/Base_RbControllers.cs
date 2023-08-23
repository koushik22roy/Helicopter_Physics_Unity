using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Base_RbControllers : MonoBehaviour
{
    #region variables
    [Header("Base Properties")]
    public float weightInLbs = 1200f;
    public Transform cog; //center of gravity

    private const float lbsToKg = 0.454f;
    private const float kgToLbs = 2.205f;

    protected Rigidbody rb;
    protected float weight;
    #endregion
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Start()
    {
        float finalKg = weightInLbs * lbsToKg;
        weight = finalKg;
        if (rb) { rb.mass = weight; }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            HandlePhysics();
        }
    }

    protected virtual void HandlePhysics() { }
    
    
}
