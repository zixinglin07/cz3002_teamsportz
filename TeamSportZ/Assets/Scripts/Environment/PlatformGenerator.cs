using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    public int reductionChance = 20;

    public ObjectGenerator[] objectGenerators;
    //public GameObject[] thePlatforms;

    //importing ObjectPooler.cs
    public ObjectPooler[] theObjectPools;
    
    private float platformWidth;
    private int platformSelector;
    private float[] platformWidths;
    private float minHeight;
    private float maxHeight;
    private float heightChange;


    
    

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        for(int i=0; i<theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + 
            distanceBetween, heightChange, transform.position.z);


            

           // Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            int chanceReduction = 0;

            foreach (ObjectGenerator generator in objectGenerators)
            {
                if (!generator.randomPlatformPosition)
                {
                    if (Random.Range(0f, 100f) < generator.GetChance() - chanceReduction)
                    {
                        generator.GenerateObject(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
                        chanceReduction += reductionChance;
                    }
                }
                else
                {
                    if (Random.Range(0f, 100f) < generator.GetChance() - chanceReduction)
                    {
                        float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2 + 1f, platformWidths[platformSelector] / 2 - 1f);
                        generator.GenerateObject(new Vector3(transform.position.x + spikeXPosition, transform.position.y + 1f, transform.position.z));
                        chanceReduction += reductionChance;
                    }
                        
                }
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2), transform.position.y, transform.position.z);
        }
    }
}
