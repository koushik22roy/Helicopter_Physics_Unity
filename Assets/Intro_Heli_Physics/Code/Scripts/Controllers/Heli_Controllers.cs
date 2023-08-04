using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(KeyboardHeli_Input))]
public class Heli_Controllers : Base_RbControllers
{
    protected override void HandlePhysics()
    {
        base.HandlePhysics();
    }

    protected virtual void HandleEngine() { }
    protected virtual void HandleCharacteristics() { }

}
