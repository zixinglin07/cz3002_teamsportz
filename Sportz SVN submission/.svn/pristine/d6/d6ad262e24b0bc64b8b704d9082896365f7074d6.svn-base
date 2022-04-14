using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public TextMeshProUGUI coin;

    public float scoreCount;
    public float coinMultiplier = 1.0f;
    private float hiScoreCount;
    public int coinCount;

    public float pointsPerSecond;

    public bool increaseScore = true;

    public void increaseCoinCount()
    {
        coinCount++;
        coin.text = "Coins: " + coinCount;
    }
    public void Multiplier(float strength)
    {
        coinMultiplier = strength;
    }
    public void resetCoins()
    {
        coinCount = 0;
        coin.text = "Coins: " + coinCount;
    }
    public int returnCoins()
    {
        return coinCount;
    }

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


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
            hiScoreText.text = "Hi-Score: " + Mathf.Round(hiScoreCount);
        }
        coin.text = "Coins: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseScore)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            hiScoreText.text = "Hi-Score: " + Mathf.Round(hiScoreCount);
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        
    }

    public void zoombieKilled(float zoombieScore)
    {
        Debug.Log("Zoombie Killed add score "+ zoombieScore);
        scoreCount += zoombieScore;
    }
 
}
