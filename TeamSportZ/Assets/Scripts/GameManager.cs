using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
       // platformList = FindObjectOfType<PlatformDestroyer>();
        //for(int i  = 0; i < platformList.length; i++)
       // {
        //    platformList[i].gameObject.setActive(false);
       // }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

    }
}
