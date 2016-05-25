using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float moveSpeedStore;
    public float jumpForce;
  
  

    // TODO These three will be used to increase speed at some point.
    public float speedMultiplier = 1.05f;
    public float speedIncreaseMilestone = 100;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;

    public float jumpTime;
    private float jumpTimecounter;

    public GameManager gameManager;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        jumpTimecounter = jumpTime;
        if (PlayerPrefs.HasKey("speedMultiplier")) {
            speedMultiplier = PlayerPrefs.GetFloat("speedMultiplier");
        }
        if (PlayerPrefs.HasKey("moveSpeed"))
        {
            moveSpeed = PlayerPrefs.GetFloat("moveSpeed");
        }
        speedMilestoneCount = speedIncreaseMilestone;
        speedMilestoneCountStore = speedMilestoneCount;
        moveSpeedStore = moveSpeed;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone *= speedMultiplier;
            moveSpeed *= speedMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<DesertPauseMenu>().PauseGame();
        }

        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimecounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimecounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimecounter = 0;
        }

        if (grounded)
        {
            jumpTimecounter = jumpTime;
        }

        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetFloat("Speed", moveSpeed);
    }

    // Used to determine when the player dies.
    // Objest need to have tag 'Killbox' added.
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Entered OCE2D.");
        if(other.gameObject.tag == "Killbox")
        {
            FindObjectOfType<GameManager>().RestartGame();
        } else
        {
            //Debug.Log("Item does not have tag 'Killbox'.");
        }
    }

    public void reset()
    {
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
        speedMilestoneCount = speedMilestoneCountStore;
        moveSpeed = moveSpeedStore;
    }
}
