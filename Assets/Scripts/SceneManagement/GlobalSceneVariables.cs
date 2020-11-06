using UnityEngine;

public class GlobalSceneVariables : MonoBehaviour
{
    // Character's which was pressed on in selection scene index
    public static string currentVehicleIndex;

    // Use this for initialization
    void Start ()
    {
        // Preventing game object from being destroyed after
        // loading next scene
        DontDestroyOnLoad(transform.gameObject);
    }
}
