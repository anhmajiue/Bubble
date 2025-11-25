using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public float gameTime = 60f; 
    private float timer;
    public TMP_Text timerText;   
    public TMP_Text scoreText;   
    public TMP_Text resultText;  
    public int winScore = 10;    

    [HideInInspector]
    public int score = 0;         
    private bool gameOver = false;

    void Start()
    {
        timer = gameTime;
        resultText.gameObject.SetActive(false);
        UpdateScoreText();
        UpdateTimerText();
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;
        UpdateTimerText();

        if (timer <= 0f)
        {
            EndGame();
        }
    }

    public void AddScore(int value)
    {
        if (gameOver) return;

        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (score >= winScore)
        {
            EndGame();
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.Ceil(timer) + "s";
    }

    void EndGame()
    {
        gameOver = true;
        resultText.gameObject.SetActive(true);

        if (score >= winScore)
        {
            resultText.text = "WIN!";
            ;
        }
        else
        {
            resultText.text = "LOSE!";
        }
        Time.timeScale = 0f;
    }
}
