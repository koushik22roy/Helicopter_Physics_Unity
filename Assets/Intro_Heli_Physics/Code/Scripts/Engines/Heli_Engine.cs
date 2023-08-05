using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Engine : MonoBehaviour
{
    #region variable
    [SerializeField] private float maxHP = 130f;    // max horse power
    [SerializeField] private float maxRPM = 2700f;  // max revolution per minute
    [SerializeField] private float powerDelay = 2f;

    [SerializeField] private AnimationCurve powerCurve = new AnimationCurve(new Keyframe(0f,0f),new Keyframe(1f,1f));
    #endregion

    #region properties
    private float currentHP;
    public float CurrentHP { get { return currentHP; } private set { } }
    private float currentRPM;
    public float CurrentRPM { get { return currentRPM; } private set { } }
    #endregion



    #region custom methods
    public void UpdateEngine(float throttleInput)
    {
        //calculate horse power
        float hp = powerCurve.Evaluate(throttleInput) * maxHP;
        currentHP = Mathf.Lerp(currentHP, hp, Time.deltaTime * powerDelay);

        //calculate rpm
        float rpm = throttleInput * maxRPM;
        currentRPM = Mathf.Lerp(currentRPM, rpm, Time.deltaTime * powerDelay);
    }
    #endregion
}
