using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{ 
    public Transform left;
    public Transform right;
    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    private float movingSpeed;
    private bool rotateBack;

    private void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        movingSpeed = -moveSpeed;

        int obstacle = Mathf.RoundToInt(Random.Range(0, 2));
        this.transform.GetChild(obstacle).gameObject.SetActive(true);
        
        if (obstacle == 1)
        {
            rotateBack = false;
            moveSpeed *= 100;
            myRigidbody.gravityScale = 0;
        }
        else
        {
            rotateBack = true;
            myRigidbody.gravityScale = 5;
        }
    }
    private void Update()
    {
        if (rotateBack)
        {
            if (Physics2D.OverlapCircle(left.position, 0.1f) == null)
            {
                movingSpeed = moveSpeed;
            }
            else if (Physics2D.OverlapCircle(right.position, 0.1f) == null)
            {
                movingSpeed = -moveSpeed;
            }
        }
        myRigidbody.velocity = new Vector2(movingSpeed, myRigidbody.velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            Debug.Log("-1 Health");
        }
    }
}
