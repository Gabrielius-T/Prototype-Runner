using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [Header("Axis to follow")]
    [SerializeField] bool xAxis;
    [SerializeField] bool yAxis;
    [Header("")]
    [SerializeField] Vector3 offset;

    Transform cTransform;
    
    void Start()
    {
        cTransform = transform;
    }
    
    void Update ()
    {
        Vector3 _objectPosition = cTransform.position;
        if (xAxis)
        {
            _objectPosition.x = objectToFollow.position.x;
        }
        if (yAxis)
        {
            _objectPosition.y = objectToFollow.position.y;
        }
        cTransform.position = _objectPosition + offset;
    }
}
