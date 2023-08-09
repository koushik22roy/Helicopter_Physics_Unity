using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(KeyboardHeli_Input))]
public class Heli_Controllers : Base_RbControllers
{
    #region Variables
    [Header("Helicopter Properties")]
    [SerializeField] private List<Heli_Engine> engines = new List<Heli_Engine>();

    [Header("Helicopter Rotor")]
    [SerializeField] private Heli_Rotors_Controller rotors_Controller;

    private Input_Controllers input;
    private Heli_Characteristics heli_Characteristics;
    #endregion

    public override void Start()
    {
        base.Start();
        heli_Characteristics = GetComponent<Heli_Characteristics>();
    }

    protected override void HandlePhysics()
    {
        input = GetComponent < Input_Controllers>();

        if (input)
        {
            HandleEngine();
            HandleRotors();
            HandleCharacteristics();
        }
    }

    protected virtual void HandleEngine() 
    { 
        //foreach(var engine in engines)
        //{
        //    engine.UpdateEngine(input.ThrottleInput);

        //    //float finalPower = engine.CurrentHP;
        //}

        for(int i = 0; i < engines.Count; i++)
        {
            engines[i].UpdateEngine(input.StickyThrottle);
            //Debug.Log("STICKY THROTTLE " + input.StickyThrottle);
            float finalPower = engines[i].CurrentHP;

            //Debug.Log("Final Power"+finalPower);
        }
    }
    protected virtual void HandleRotors() 
    {
        if (rotors_Controller && engines.Count>0)
        {
            rotors_Controller.UpdateRotors(input, engines[0].CurrentRPM);
            //Debug.LogError("Current RPM" + engines[0].CurrentRPM);
        }
    }
    protected virtual void HandleCharacteristics() 
    {
        if (heli_Characteristics)
        {
            heli_Characteristics.UpdateCharacteristics(rb,input);
        }
    }
}
