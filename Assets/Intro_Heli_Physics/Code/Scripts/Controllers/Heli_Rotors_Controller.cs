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
        rotors = GetComponentsInChildren<IHeliRotor>().ToList();
    }

    public void UpdateRotors(Input_Controllers inputController, float currentRPM)
    {
        float dps = ((currentRPM * 360f) / 60f);

        if (rotors.Count > 0)
        {
            foreach(var rotor in rotors)
            {
                rotor.UpdateRotor(dps,inputController);
            }
        }
    }
}
