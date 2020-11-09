using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float movementSpeed = 0;
    [SerializeField] Text distanceText;
    [SerializeField] PlayerStatsController playerStatsController;

    Rigidbody2D rb;
    Vector2 initialPos;
    int distanceTravelled;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = rb.position;
    }
	
	void Update ()
    {
        Run();
    }

    void Run()
    {
        Vector2 _position = transform.position;
        _position.x += Time.deltaTime * movementSpeed;
        transform.position = _position;
        distanceTravelled = (int)Vector2.Distance(initialPos, rb.position);
        playerStatsController.pd.maxDistance = distanceTravelled;
        distanceText.text = distanceTravelled.ToString();
    }
}
