using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float movementSpeed = 0;

    [SerializeField]
    private Text distance;

    [SerializeField]
    private PlayerStatsController playerStatsController;

    private Rigidbody2D rb;

    private Vector2 initialPos;

    private int distanceTravelled;

	private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = rb.position;
    }
	
	private void Update ()
    {
        Run();
    }

    private void Run()
    {
        Vector2 _position = transform.position;
        _position.x += Time.deltaTime * movementSpeed;
        transform.position = _position;
        distanceTravelled = (int)Vector2.Distance(initialPos, rb.position);
        playerStatsController.pd.maxDistance = distanceTravelled;
        distance.text = distanceTravelled.ToString();
    }
}
