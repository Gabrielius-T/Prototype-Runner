using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject cameraToFollow;
    public Vector3 cameraOffset;

    // Update is called once per frame
    void Update () {
        cameraToFollow.transform.position = new Vector3(transform.position.x, cameraToFollow.transform.position.y, cameraToFollow.transform.position.z) + cameraOffset;
    }
}
