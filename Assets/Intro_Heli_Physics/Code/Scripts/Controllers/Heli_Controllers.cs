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
    #endregion

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
        foreach(Heli_Engine engine in engines)
        {
            engine.UpdateEngine(input.ThrottleInput);

            float finalPower = engine.CurrentHP;
        }
    }
    protected virtual void HandleRotors() 
    {
        if (rotors_Controller && engines.Count>0)
        {
            rotors_Controller.UpdateRotors(input, engines[0].CurrentRPM);
        }
    }
    protected virtual void HandleCharacteristics() { }


}
