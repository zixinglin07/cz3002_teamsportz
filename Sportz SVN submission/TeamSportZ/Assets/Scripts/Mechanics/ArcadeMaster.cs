using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMaster : Enhancement
{
    float defaultTime = 1.0f;
    public float incrementTime = 1.0f;

    public override void Empower()
    {
        Mechanic.enhancementTime = 1.0f + (incrementTime * base.enhancementLevel);    
    }
}
