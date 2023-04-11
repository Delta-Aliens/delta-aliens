using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    public CharacterController controller;
    public Animator animator;


    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder)
        {
            isClimbing = true;
            Debug.Log(isClimbing);
            animator.SetBool("isClimbing", true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            // rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            controller.m_JumpForce = 50f;
        }
        else
        {
            // rb.gravityScale = 3f;
        }
        controller.m_JumpForce = 800f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            // animator.SetBool("isClimbing", false);
        }
    }
}