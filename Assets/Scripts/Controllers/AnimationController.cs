using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 4f)]
    private float rotationSpeed;

    private Rigidbody2D rb;

    private Vector3 jumpUpAngle;
    private Vector3 jumpDownAngle;
    private Vector3 idleAngle;
    private Vector3 currentAngle;

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpUpAngle = new Vector3(0, 0, 15f);
        jumpDownAngle = new Vector3(0, 0, -15f);
        idleAngle = new Vector3(0, 0, 0f);
    }
	
	private void Update ()
    {
		if(rb.velocity.y > 5f)
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, jumpUpAngle.x, Time.deltaTime * rotationSpeed),
                                       Mathf.LerpAngle(currentAngle.y, jumpUpAngle.y, Time.deltaTime * rotationSpeed),
                                       Mathf.LerpAngle(currentAngle.z, jumpUpAngle.z, Time.deltaTime * rotationSpeed));
            transform.eulerAngles = currentAngle;
        }
        else if (rb.velocity.y < -1f)
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, jumpDownAngle.x, Time.deltaTime * rotationSpeed),
                                       Mathf.LerpAngle(currentAngle.y, jumpDownAngle.y, Time.deltaTime * rotationSpeed),
                                       Mathf.LerpAngle(currentAngle.z, jumpDownAngle.z, Time.deltaTime * rotationSpeed));
            transform.eulerAngles = currentAngle;
        }
        else
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, idleAngle.x, Time.deltaTime * rotationSpeed * 2f),
                                       Mathf.LerpAngle(currentAngle.y, idleAngle.y, Time.deltaTime * rotationSpeed * 2f),
                                       Mathf.LerpAngle(currentAngle.z, idleAngle.z, Time.deltaTime * rotationSpeed * 2f));
            transform.eulerAngles = currentAngle;
        }
	}
}
