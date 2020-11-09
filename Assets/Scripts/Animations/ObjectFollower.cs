using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;

    Transform cTransform;
    
    void Start()
    {
        cTransform = transform;
    }
    
    void Update ()
    {
        Vector3 _objectPosition = objectToFollow.position;
        cTransform.position = new Vector3(_objectPosition.x, _objectPosition.y, _objectPosition.z) + offset;
    }
}
