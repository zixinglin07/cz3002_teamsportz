using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaster : Enhancement
{
    public float incrementMultiplier = 0.1f;
    float multiplier = 1.0f;

    public override void Empower()
    {
        ScoreManager.instance.Multiplier(multiplier + (incrementMultiplier * base.enhancementLevel)); 
    }

}
