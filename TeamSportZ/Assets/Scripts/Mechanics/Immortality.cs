using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortality : Enhancement
{
    PlayerController player = null;
    private float duration = 3.0f;
    
    public override void Empower()
    {
        if (ScoreManager.instance.increaseScore)
        {
            //CODE TO BE REPLACED
            player = FindObjectOfType<PlayerController>();
            //player.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //throw new System.NotImplementedException();
            StartCoroutine(InvincibilityPower(duration + (1 * base.enhancementLevel)));
        }
    }
    IEnumerator InvincibilityPower(float time)
    {
        float timeCounter = 0.0f;
        while (timeCounter < time)
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


    }
}
