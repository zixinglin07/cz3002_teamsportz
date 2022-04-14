using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public ScoreManager theScoreManager;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        scoreText.text = "" + Mathf.Round(theScoreManager.scoreCount);
        coinText.text = "" + Mathf.Round(theScoreManager.coinCount);
    }
    public void Update()
    {
        scoreText.text = "" + Mathf.Round(theScoreManager.scoreCount);
        coinText.text = "" + Mathf.Round(theScoreManager.coinCount);
    }
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}
