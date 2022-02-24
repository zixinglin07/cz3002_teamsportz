using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;
    private float speedIncreaseMileStoneStore;

    private float speedMileStoneCountScore;
    public bool grounded;
    public LayerMask whatIsGround;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Animator myAnimator;


    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        moveSpeedStore = moveSpeed;
        //speedMileStoneCountScore = speedMileStoneCount;
        //speedIncreaseMileStoneStore = speedIncreaseMilseStoneStore;

    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);

       

        //jump if space is pressed or mouse is clicked
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x , jumpForce);
            }
            
        }

        myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool ("Grounded", grounded);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            Debug.Log("hi");
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            //speedMilestoneCount = speedMileStoneCountScore;
            //speedIncreaseMileStone = speedIncreaseMileStoneStore;
        }
    }
}
