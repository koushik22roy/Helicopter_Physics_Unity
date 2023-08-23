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

    private Input_Controllers inputController;
    private Heli_Characteristics heli_Characteristics;
    #endregion

    public List<Heli_Engine> Engines
    {
        get { return engines; }
    }

    public override void Start()
    {
        base.Start();
        heli_Characteristics = GetComponent<Heli_Characteristics>();
    }

    protected override void HandlePhysics()
    {
        inputController = GetComponent <Input_Controllers>();
        base.HandlePhysics();
        if (inputController)
        {
            HandleEngine();
            HandleRotors();
            HandleCharacteristics();
        }
    }

    protected virtual void HandleEngine() 
    { 
        for(int i = 0; i < engines.Count; i++)
        {
            engines[i].UpdateEngine(inputController.StickyThrottle);
            float finalPower = engines[i].CurrentHP;
        }
    }
    protected virtual void HandleRotors() 
    {
        if (rotors_Controller && engines.Count>0)
        {
            rotors_Controller.UpdateRotors(inputController, engines[0].CurrentRPM);
        }
    }
    protected virtual void HandleCharacteristics() 
    {
        if (heli_Characteristics)
        {
            heli_Characteristics.UpdateCharacteristics(rb,inputController);
        }
    }
}
