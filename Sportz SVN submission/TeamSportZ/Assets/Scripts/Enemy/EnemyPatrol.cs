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

    int currentPhase = 0;


    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        player = FindObjectOfType<PlayerController>();
        
        canAttack = false;
    }

    private void OnEnable()
    {
        //myRigidbody = this.GetComponent<Rigidbody2D>();
        //movingSpeed = -moveSpeed;
        
        currentPhase = GameManager.instance.CurrentTransitionPhase();
        this.transform.GetChild(currentPhase).gameObject.SetActive(true);

        if (currentPhase == 1)
        {
            //rotateBack = false;
            //moveSpeed *= 100;
            //myRigidbody.gravityScale = 0;
        }
        else
        {
            //rotateBack = true;
            //myRigidbody.gravityScale = 5;
        }
    }

    private void OnDisable()
    {
        this.transform.GetChild(currentPhase).gameObject.SetActive(false);
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
            // Below code are for attack: stop patrol then attack
            //mustPatrol = false;
            //rb.velocity = Vector2.zero;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            collision.GetComponent<Health>().DeductHealth();            
        }        
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

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
