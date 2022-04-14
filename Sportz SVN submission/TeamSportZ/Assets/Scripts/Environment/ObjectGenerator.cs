using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;
    public int sideCoinsToGenerate = 1;
    public float distanceBetweenCoins;
    public int chanceToGenerate;
    public bool randomPlatformPosition;

    public int GetChance()
    {
        return chanceToGenerate;
    }
    public void GenerateObject(Vector3 startPosition)
    {
        for (int i = -sideCoinsToGenerate; i <= sideCoinsToGenerate; i++)
        {
            Vector3 positionToCheck = new Vector3(startPosition.x + (i * distanceBetweenCoins), startPosition.y, startPosition.z);

            if (Physics2D.OverlapCircle(positionToCheck, 0.1f) == null)
            {
                GameObject coin = coinPooler.GetPooledObject();
                coin.transform.position = positionToCheck;
                coin.SetActive(true);
            }
            else
            {
                continue;
            }

        }
    }
}
