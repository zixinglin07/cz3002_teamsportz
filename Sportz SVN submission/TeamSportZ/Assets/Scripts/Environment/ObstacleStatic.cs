using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStatic : MonoBehaviour
{
    int currentPhase = 0;
    private void OnEnable()
    {
        currentPhase = GameManager.instance.CurrentTransitionPhase();
        this.transform.GetChild(currentPhase).gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        this.transform.GetChild(currentPhase).gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //TO BE REPLACED
            collision.GetComponent<Health>().DeductHealth();
        }
    }
}
