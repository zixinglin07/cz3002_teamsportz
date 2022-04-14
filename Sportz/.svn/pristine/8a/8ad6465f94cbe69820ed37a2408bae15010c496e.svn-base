using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float startHealth;
    private float hp;

    public GameObject diePEffect;
    public ScoreManager theScoreManager;
    void Start()
    {
        hp = startHealth;
        theScoreManager = FindObjectOfType<ScoreManager>();
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
        theScoreManager.zoombieKilled(500);
        if (diePEffect != null)
        {
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
