using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    public PlatformGenerator generator;
    public ScoreManager theScoreManager;
    private CharacterSwitch switchPlayer;

    public float transitionTime;
    public float speedIncreaseTime;
    public int increaseDifficulty = 3;
    private float timeCounter;
    private float speedTimeCounter;
    private int transitionPhase = 0;

    private Vector3 playerStartPoint;
    private ObjectDestroyer[] platformList;
    
    public DeathMenu theDeathScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public int CurrentTransitionPhase()
    {
        return transitionPhase;
    }
    void Start()
    {
        transitionTime *= 60;
        speedIncreaseTime *= 60;
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        switchPlayer = thePlayer.GetComponent<CharacterSwitch>();
        ResourceManager.instance.EnableEnhancement();
        //theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theScoreManager.increaseScore)
        {
            timeCounter += Time.deltaTime;
            speedTimeCounter += Time.deltaTime;

            if (timeCounter > (transitionTime))
            {
                transitionPhase += 1;
                transitionPhase %= 2;
                Debug.Log("Phase: " + transitionPhase);
                timeCounter = 0;
                Transition();
            }

            if (speedTimeCounter > speedIncreaseTime)
            {
                thePlayer.moveSpeed++;
                if (generator.reductionChance > 0)
                    generator.reductionChance -= increaseDifficulty;
                speedTimeCounter = 0;
            }
        }
    }

    public void RestartGame()
    {
        theScoreManager.increaseScore = false;
        if (ResourceManager.instance != null)
            ResourceManager.instance.AddCoin(ScoreManager.instance.returnCoins());
       
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);
        transitionPhase = 0;
        switchPlayer.SwitchCharacter(transitionPhase);
        timeCounter = 0;
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<ObjectDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        thePlayer.GetComponent<Health>().ResetHealth();

        theScoreManager.scoreCount = 0;
        theScoreManager.coinCount = 0;
        theScoreManager.increaseScore = true;
        ScoreManager.instance.resetCoins();
    }
    public void Transition()
    {
        switchPlayer.SwitchCharacter(transitionPhase);
    }
    /*public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<ObjectDestroyer>();
        for(int i  = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

    }*/
}
