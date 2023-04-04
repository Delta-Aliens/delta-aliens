using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    #region SINGLETON PATTERN
    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerController>();
            }

            return _instance;
        }
    }
    #endregion
    public CharacterController controller;
    public Animator animator;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    float fallTimer = 0f;
    public bool isFrozen;
    
    // Update is called once per frame
    void Update () {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            // Player is crouching
            crouch = true;
            // // Shrink the collider
            GetComponent<BoxCollider2D>().size = new Vector2(5.123321f, 10.98985f);

        } else if (Input.GetButtonUp("Crouch"))
        {
            // Check if anything is blocking the path of the player's collider
            crouch = false;

            GetComponent<BoxCollider2D>().size = new Vector2(5.123321f, 14.61552f);

        // IF player is already walking and presses shift, start sprinting
        } else if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(horizontalMove) > 0)
        {
            // Player is sprinting
            runSpeed = 80f;

            // set the animator to sprinting
            animator.SetFloat("Speed", runSpeed);

        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // Player is no longer sprinting
            runSpeed = 40f;

            // set the animator to walking
            animator.SetFloat("Speed", runSpeed);
        }

        // If the player is crouching and moving, shrink the collider
        // if (crouch && Mathf.Abs(horizontalMove) > 0)
        // {
        //     // Player is crouching and moving
        //     GetComponent<CircleCollider2D>().radius = Time.time * .01f;
        // }   
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        // detect a player falling and not stuck in the air
        if (!controller.IsGrounded() && !animator.GetBool("IsJumping"))
        {
            // Increment the fall timer
            fallTimer += Time.fixedDeltaTime;

            // If the fall timer reaches 5 seconds, play the fall animation
            if (fallTimer >= 5f)
            {
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }
        }
        else
        {
            // Reset the fall timer if the player is grounded
            fallTimer = 0f;
        }
    }

    //Freezing the player in place
    public void SetFrozen()
    {
        isFrozen = true;
        Debug.Log("Frozen");
    }
    //Unfreezing the player; back in motion again
    public void UnFrozen()
    {
        isFrozen = false;
        Debug.Log("Not frozen");
    }

    public void onLanding()  {
        animator.SetBool("IsJumping", jump);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
}