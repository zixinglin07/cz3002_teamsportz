using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed,range, timeBTWAttacks, attackSpeed;
    private float distToPlayer;

    public bool mustPatrol;
    private bool mustTurn, canAttack;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public GameObject weapon;
    public Transform attackPos;
    private PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        player = FindObjectOfType<PlayerController>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distToPlayer <= range)
        {
            if(player.transform.position.x > transform.position.x && transform.localScale.x < 0
                || player.transform.position.x < transform.position.x && transform.localScale.x > 0)
            {
                // flip if player in enemy right but enemy facing left
                // flip if player in enemy left but enemy facing right
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if(canAttack)
            StartCoroutine(Attack());
        }
        else
        {
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer))
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed , rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x* -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    IEnumerator Attack()
    {
        canAttack = false;
        //Shoot
        yield return new WaitForSeconds(timeBTWAttacks);
        GameObject newWeapon = Instantiate(weapon, attackPos.position,Quaternion.identity);
        Vector2 direction = player.transform.position +(player.transform.up*0.5f);
        attackPos.transform.LookAt(direction);
        newWeapon.GetComponent<Rigidbody2D>().AddForce( attackPos.transform.forward * attackSpeed);
        //newWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(walkSpeed)*direction.x* attackSpeed, (direction.y)*attackSpeed);
        canAttack = true;


    }
}
