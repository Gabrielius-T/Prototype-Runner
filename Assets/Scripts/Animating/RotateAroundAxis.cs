using UnityEngine;

[System.Serializable] // needed for unity editor to remember set values
public class RotateAroundAxis : MonoBehaviour {
    public enum Axis { x, y, z }; // axis enumerator
    public float speed = 2; // rotation Speed
    public float maxRotation = 0.17f; // max rotating 
    public Axis currentAxis = Axis.z; // axis to rotate around

    void Update()
    {
        switch (currentAxis) {
            case Axis.x:
                transform.RotateAround(transform.position, transform.right, maxRotation * Mathf.Sin(Time.time * speed));
                break;
            case Axis.y:
                transform.RotateAround(transform.position, transform.up, maxRotation * Mathf.Sin(Time.time * speed));
                break;
            case Axis.z:
                transform.RotateAround(transform.position, transform.forward, maxRotation * Mathf.Sin(Time.time * speed));
                break;
        }
    }
}
