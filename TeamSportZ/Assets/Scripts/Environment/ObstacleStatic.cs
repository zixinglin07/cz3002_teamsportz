using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStatic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            Debug.Log("-1 Health");
        }
    }
}
