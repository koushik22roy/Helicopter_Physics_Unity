using UnityEngine;
using UnityEditor;


public class HeliCopterMenus 
{
    [MenuItem("Vehicles/Setup New Helicopter")]
    public static void BuildNewHelicopter() 
    {
        GameObject currHeli = new GameObject("New_Helicopter",typeof(Heli_Controllers));

        GameObject currCog = new GameObject("Center_Of_Gravity");
        currCog.transform.SetParent(currHeli.transform);

        Heli_Controllers currController = currHeli.GetComponent<Heli_Controllers>();
        currController.cog = currCog.transform;

        Selection.activeObject = currHeli;
    }
}
