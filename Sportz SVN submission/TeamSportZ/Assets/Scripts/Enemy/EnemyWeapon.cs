using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float dieTime, damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            Die();
            //Debug.Log("-1 Health");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    IEnumerator CountDownTimer()
    {
        // die after x sec if nvr hit player
        yield return new WaitForSeconds(dieTime);
        Die();
    }
}
