using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Advanced_Heli_Camera))]
public class AdvancedHeliCamera_Editor : Editor
{
    private Advanced_Heli_Camera advanced_Heli_Camera;
    private void OnEnable()
    {
        advanced_Heli_Camera = (Advanced_Heli_Camera)target;
    }

    private void OnSceneGUI()
    {
        float minDist = advanced_Heli_Camera.minDistance;
        float maxDist = advanced_Heli_Camera.maxDistance;

        Vector3 targetFwd = advanced_Heli_Camera.rb.transform.forward;
        targetFwd.y = 0f;
        targetFwd = targetFwd.normalized;

        Handles.color = Color.blue;
        Handles.DrawWireDisc(advanced_Heli_Camera.rb.position, Vector3.up, minDist);
        Handles.DrawWireDisc(advanced_Heli_Camera.rb.position, Vector3.up, maxDist);

        advanced_Heli_Camera.minDistance = Handles.ScaleSlider(advanced_Heli_Camera.minDistance, advanced_Heli_Camera.rb.position + (targetFwd * minDist), Vector3.forward, Quaternion.identity, 1f, 1f);
        advanced_Heli_Camera.minDistance = Handles.ScaleSlider(advanced_Heli_Camera.maxDistance, advanced_Heli_Camera.rb.position + (targetFwd * maxDist), Vector3.forward, Quaternion.identity, 1f, 1f);

    }
}
