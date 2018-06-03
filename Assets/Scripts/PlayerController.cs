using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    private float moveSpeedStore; //stores the player's movespeed value at the very start of the game, so that the game can reset player's speed to default at restart. see Start()
    public float speedMultiplier; //set in the inspector, this value determines what multiplication of speed our player gets upon hitting the milestone.

    public float speedIncreaseMilestone; //how far thePlayer must move before getting a boost of speed.
    private float speedIncreaseMilestoneStore; // stores the speedIncreaseMilestone value at the start of the game, so the game can reset player's milestone at restart.

    private float speedMilestoneCount; //the point at which he speeds up
    private float speedMilestoneCountStore; //stores the speedmilestonecount at the very start of the game so that game can reset players count at restart.



    public float jumpForce;

    public float jumpTime; //if you hold down the button how long will the player continue rising?

    private float jumpTimeCounter; //how long we have held button for.

    private bool stoppedJumping; //becomes true when we hit the ground, becomes false when we start jumping
    private bool canDoubleJump;//you can double jump while you are in the air and you have not already double jumped


    public GameManager theGameManager;


    //private Collider2D myCollider;

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck; //small circle on character feet which checks if he is touching a ground item
    public float groundCheckRadius; //how big is the radius on this circle?
    
    


    // Use this for initialization
    void Start ()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime; //we set out jump time equal to default

        speedMilestoneCount = speedIncreaseMilestone; //we are setting out milestone to default

        moveSpeedStore = moveSpeed; //our stored value of movespeed is equal to whatever movespeed value we start with.
        speedMilestoneCountStore = speedMilestoneCount; //our stored value for speedIncreaseMilestoneCount is equal to whatever value we start with.
        speedIncreaseMilestoneStore = speedIncreaseMilestone; //our stored value for Speed Increase Milestone is equal to whatever value we start the game with.

        stoppedJumping = true;
        canDoubleJump = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

       //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); //we determine if player is grounded by seein if the player's collider is touching the ground layer
       grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMilestoneCount) //if we have reached a speed milestone...
        {
            speedMilestoneCount += speedIncreaseMilestone; // add to our speed milestone


            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; // multiply our speedmultiplier onto the speedincreasemilestone so that it gets harder to reach speed milestones
            moveSpeed = moveSpeed * speedMultiplier; // increase our speed
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                
                
            }

            if (!grounded && canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                Debug.Log("Double Jumped");
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;

        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);


		
	}

    private void OnCollisionEnter2D(Collision2D other) //when this player obj touches some OTHER obj (with a box collider 2D component)...
    {
        if (other.gameObject.tag == "killbox") //we created a tag called killbox and attached it to the catcher in the Inspector.
        {
            theGameManager.RestartGame(); //a ref to the RestartGame function inside our gamemanager script.
            moveSpeed = moveSpeedStore; //reset our speed to whatever it was on the first frame of the game. See Start() function
            speedMilestoneCount = speedMilestoneCountStore; //reset our speedincreasemilestonecount to whatever it was on the first frame. (Default value)
            speedIncreaseMilestone = speedIncreaseMilestoneStore; //reset our speedincreasemilestone to whatever it was on the first frame of the game. (Default value)
        }
    }

}
