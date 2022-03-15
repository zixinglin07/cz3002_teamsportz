using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : Mechanic
{
    public PlayerController player;

    public static float durationLast;
    private static bool running = false;

    public override void Empower()
    {
        if (ScoreManager.instance.increaseScore)
        {
            //CODE TO BE REPLACED
            player = FindObjectOfType<PlayerController>();
            //player.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            durationLast += base.TotalTime();

            //throw new System.NotImplementedException();
            if (!running)
                StartCoroutine(InvincibilityPower(base.TotalTime()));
        }
    }
    // Update is called once per frame
    IEnumerator InvincibilityPower(float time)
    {
        running = true;

        float timeCounter = 0.0f;
        while (timeCounter < durationLast)
        {
            //CODE TO BE REPLACED
            player.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            if (player.gameObject.layer != LayerMask.NameToLayer("Invincibility"))
                player.gameObject.layer = LayerMask.NameToLayer("Invincibility");

            timeCounter += Time.deltaTime;

            yield return null;
        }
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        //CODE TO BE REPLACED
        player.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        /*this.gameObject.layer = LayerMask.NameToLayer("Invincibility");

        yield return new WaitForSeconds(time);

        this.gameObject.layer = LayerMask.NameToLayer("Player");*/
        running = false;
        durationLast = 0;
       
    }

   
}
