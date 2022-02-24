using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : Mechanic
{
    public PlayerController player;
    public float magnetDuration;
    public float magnetRadius;
    public LayerMask layerToUse;

    public override void Empower()
    {
        //CODE TO BE REPLACED
        player = FindObjectOfType<PlayerController>();
        //player.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        //throw new System.NotImplementedException();
        StartCoroutine(Magnet(magnetDuration));
        
    }
    IEnumerator Magnet(float time)
    {
        float timeCounter = 0.0f;
        while (timeCounter < time)
        {
            //CODE TO BE REPLACED
            player.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            Collider2D[] collidersNearby = Physics2D.OverlapCircleAll(player.transform.position, magnetRadius, layerToUse);
            foreach (Collider2D col in collidersNearby)
            {
                if (Vector3.Distance(col.gameObject.transform.position, player.transform.position) < 0.01f)
                {
                    continue;
                }
                col.gameObject.transform.position = Vector3.MoveTowards(col.gameObject.transform.position, player.transform.position, 0.05f);
            }

            timeCounter += Time.deltaTime;
            yield return null;
        }
        ResetPowerUp();
        //CODE TO BE REPLACED
        player.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    
}
