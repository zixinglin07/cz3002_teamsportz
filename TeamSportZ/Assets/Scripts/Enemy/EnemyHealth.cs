using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float startHealth;
    private float hp;

    public GameObject diePEffect;
    void Start()
    {
        hp = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamge(float damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
