using System;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoSingleton<MovementController>
{
    [SerializeField] [Range(0, 10)] float movementSpeed = 0;
    [SerializeField] Text distanceText;
    [SerializeField] float jumpForce;

    internal Rigidbody2D rb;
    const float delayAfterInput = 0.1f;
    Transform cTransform;
    Vector2 initialPos;
    int distanceTravelled;
    int jumpsCount;
    bool canResetCounter;
    float startingY;
    float timeSinceInput;

	void Start ()
    {
        cTransform = transform;
        rb = GetComponent<Rigidbody2D>();
        initialPos = rb.position;
        startingY = cTransform.position.y;
    }
	
	void Update ()
    {
        Run();
    }

    void LateUpdate()
    {
        timeSinceInput += Time.deltaTime;
        canResetCounter = timeSinceInput >= delayAfterInput;
        if (Mathf.Abs(startingY - cTransform.position.y) < 0.001f && canResetCounter)
        {
            jumpsCount = 0;
        }
        if(Input.GetMouseButtonDown(0) && jumpsCount < 2)
        {
            Jump();
        }
    }

    void Jump()
    {
        timeSinceInput = 0f;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce);
        jumpsCount++;
    }

    void Run()
    {
        Vector2 _position = cTransform.position;
        _position.x += Time.deltaTime * movementSpeed;
        _position.y = Mathf.Max(startingY, _position.y);
        cTransform.position = _position;
        distanceTravelled = (int)Vector2.Distance(initialPos, rb.position);
        PlayerStatsController.instance.pd.maxDistance = distanceTravelled;
        distanceText.text = distanceTravelled.ToString();
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        int _layer = _other.gameObject.layer;
        if (_layer == 13)
        {
            jumpsCount = 0;
        }
    }
}
