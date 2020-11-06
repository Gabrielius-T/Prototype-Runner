using UnityEngine;
using DragonBones;
using System.Collections;

public class ActionsController : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D upperCollider;

    [SerializeField]
    private PolygonCollider2D lowerCollider;

    [SerializeField]
    private AudioSource jumpSound;

    [SerializeField]
    private AudioSource slideSound;

    private UnityArmatureComponent animator;

    internal bool onDownClicked;

    private bool canEvadeAgain = true;

    private bool canJump;

    private Rigidbody2D rb;

	private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<UnityArmatureComponent>();
        animator.animation.Play("Run_Ripped_run");
    }
	
	private void Update ()
    {
        if (animator.animation.isCompleted)
        {
            animator.animation.Play("Run_Ripped_run");
        }
        if (animator.animation.lastAnimationName.Equals("Run_Ripped_run"))
        {
            upperCollider.enabled = true;
        }
    }

    public void OnDownClick()
    {
        Collider2D[] cols = new Collider2D[10];
        ContactFilter2D contactFilter = new ContactFilter2D();
        if (lowerCollider.OverlapCollider(contactFilter, cols) != 0)
        {
            onDownClicked = true;
            StartCoroutine(ResetOnDownClicked());
        }
        if (!canEvadeAgain)
        {
            return;
        }
        if(transform.position.y <= 0f)
        {
            animator.animation.Play("Run_Ripped_evade_slide", 1);
            slideSound.Play();
            upperCollider.enabled = false;
        }
        canEvadeAgain = false;
        StartCoroutine(WaitForEvadeToReset());
    }

    public void OnUpClick()
    {
        if (canJump || (rb.velocity.y > -1f && rb.velocity.y < 0.1f))
        {
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    private IEnumerator WaitForEvadeToReset()
    {
        yield return new WaitForSeconds(0.7f);
        canEvadeAgain = true;
    }

    private IEnumerator ResetOnDownClicked()
    {
        yield return new WaitForSeconds(0.2f);
        onDownClicked = false;
    }
}
