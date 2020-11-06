using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField]
    private bool allSides;

    [SerializeField]
    private bool bottomSide;

    [SerializeField]
    private bool topSide;

    [SerializeField]
    private bool noSides;

    [SerializeField]
    private BoxCollider2D upperCollider;

    [SerializeField]
    private PlayerStatsController playerStatsController;

    [SerializeField]
    private GameObject character;

    private ActionsController actionsController;

    private Rigidbody2D characterRb;

    private void Start()
    {
        //Application.targetFrameRate = 60;
        characterRb = character.GetComponent<Rigidbody2D>();
        actionsController = character.GetComponent<ActionsController>();
    }

    private void Update()
    {
        CheckForContact();
        ChangeColliderToTrigger();
    }

    private void CheckForContact()
    {
        ContactPoint2D[] cps = new ContactPoint2D[1];
        upperCollider.GetContacts(cps);
        if (Vector2.Distance(cps[0].normal, new Vector2(0.0f, -1.0f)) < 1f && (allSides || topSide))
        {
            playerStatsController.RemoveLife();
        }
    }

    /// <summary>
    /// Allows for character to jump through collider
    /// under certain circumstances
    /// </summary>
    private void ChangeColliderToTrigger()
    {
        if(characterRb.velocity.y != 0.0f)
        {
            if (actionsController.onDownClicked)
            {
                upperCollider.isTrigger = true;
                return;
            }
            if (characterRb.velocity.y < -1.0f)
            {
                upperCollider.isTrigger = false;
            }
            else
            {
                upperCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        upperCollider.isTrigger = true;
        if ((bottomSide || allSides) && characterRb.velocity.y >= -0.1f)
        {
            playerStatsController.RemoveLife();
        }
    }
}
