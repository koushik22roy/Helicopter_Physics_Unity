using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor_Blur : MonoBehaviour, IHeliRotor
{
    [Header("Rotor Blur Properties")]
    [SerializeField] private float maxDPS = 323f;
    [SerializeField] private List<GameObject> blades = new List<GameObject>();
    [SerializeField] private GameObject blur;
    public List<Texture2D> blurTex = new List<Texture2D>();


    [SerializeField] private Material blurMat;
    [SerializeField] private GameObject blurGeo;
    //[SerializeField] private GameObject doubleSideBlurGeo;

    public void UpdateRotor(float dps, Input_Controllers input)
    {
        float normalizedDPS = Mathf.InverseLerp(0f, maxDPS, dps);
        int blurTexId = Mathf.FloorToInt(normalizedDPS * blurTex.Count-1);
        //Debug.Log("Normalized " + normalizedDPS);

        blurTexId = Mathf.Clamp(blurTexId,0, blurTex.Count - 1);
        if (blurMat && blurTex.Count > 0)
        {
            blurMat.SetTexture("_MainTex", blurTex[blurTexId]);
        }

        if (blurTexId > 1 && blades.Count > 0)
        {
            HandleGeo(false);
        }
        else
        {
            HandleGeo(true);
        }

    }


    private void HandleGeo(bool activeness)
    {
        foreach (GameObject blade in blades)
        {
            blade.SetActive(activeness);
            blurGeo.SetActive(!activeness);
            //doubleSideBlurGeo.SetActive(!activeness);
        }
    }
}
