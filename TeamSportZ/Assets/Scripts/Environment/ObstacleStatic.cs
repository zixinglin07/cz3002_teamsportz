using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStatic : MonoBehaviour
{
    private void Start()
    {
        this.transform.GetChild(Mathf.RoundToInt(Random.Range(0, 2))).gameObject.SetActive(true);
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
