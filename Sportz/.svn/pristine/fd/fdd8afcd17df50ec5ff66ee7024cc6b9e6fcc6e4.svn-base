using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : Mechanic
{
    public PlayerController player;
    public float magnetRadius;
    public LayerMask layerToUse;

    public static float durationLast;
    private static bool running = false;


    public override void Empower()
    {
        //CODE TO BE REPLACED
        player = FindObjectOfType<PlayerController>();
        //player.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        //throw new System.NotImplementedException();
        durationLast += base.TotalTime();
        if (!running)
            StartCoroutine(Magnet(base.TotalTime()));
        
    }
    IEnumerator Magnet(float time)
    {
        running = true;

        float timeCounter = 0.0f;
        while (timeCounter < durationLast)
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
                col.gameObject.transform.position = Vector3.MoveTowards(col.gameObject.transform.position, player.transform.position, 50f * Time.deltaTime);
            }

            timeCounter += Time.deltaTime;
            yield return null;
        }
        ResetPowerUp();
        //CODE TO BE REPLACED
        player.gameObject.transform.GetChild(1).gameObject.SetActive(false);

        running = false;
        durationLast = 0;
    }
    
}
