using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    private float movingSpeed;

    private void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        movingSpeed = moveSpeed;
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(left.position, 0.1f) == null)
        {
            movingSpeed = moveSpeed;
        }
        else if (Physics2D.OverlapCircle(right.position, 0.1f) == null)
        {
            movingSpeed = -moveSpeed;
        }
        myRigidbody.velocity = new Vector2(movingSpeed, myRigidbody.velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            
            Debug.Log("-1 Health");
            movingSpeed = 0;
        }
        else
        {
            movingSpeed = -moveSpeed;
        }
    }
}
