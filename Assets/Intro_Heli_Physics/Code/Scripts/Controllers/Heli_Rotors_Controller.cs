using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Heli_Rotors_Controller : MonoBehaviour
{
    #region variable
    private List<IHeliRotor> rotors;
    #endregion

    private void Start()
    {
        rotors = new List<IHeliRotor>(GetComponentsInChildren<IHeliRotor>());
    }

    public void UpdateRotors(Input_Controllers input, float currentRPM)
    {
        //degree per seconds 
        float dps = ((currentRPM * 360) / 60)*Time.deltaTime;

        if(rotors.Count > 0)
        {
            foreach(var rotor in rotors)
            {
                rotor.UpdateRotor(dps,input);
            }
        }
    }
}
