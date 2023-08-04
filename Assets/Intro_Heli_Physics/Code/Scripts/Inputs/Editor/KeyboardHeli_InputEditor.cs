using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(KeyboardHeli_Input))]
public class KeyboardHeli_InputEditor : Editor 
{
    #region variables
    private KeyboardHeli_Input keyboardHeli_Input;
    #endregion

    private void OnEnable()
    {
        keyboardHeli_Input = (KeyboardHeli_Input)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawDebugGUI();
    }

    #region Custon Methods
    private void DrawDebugGUI()
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.Space();
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Throttle: " + keyboardHeli_Input.ThrottleInput);
        EditorGUILayout.LabelField("Collective: " + keyboardHeli_Input.CollectiveInput);
        EditorGUILayout.LabelField("Cyclic: " + keyboardHeli_Input.CyclicInput);
        EditorGUILayout.LabelField("Pedals: " + keyboardHeli_Input.PedalInput);
        EditorGUI.indentLevel--;
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }
    #endregion
}
