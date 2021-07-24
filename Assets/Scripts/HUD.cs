using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour //INHERITANCE
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;
    [SerializeField] private GameObject GameOverText;


    private void Awake()
    {
        UpdateHighScore(MainManager.Instance.playerName, MainManager.Instance.GetCurrentHighScore());
    }

    public void UpdateScore()
    {
        ScoreText.text = $"Score : {MainManager.Instance.GetCurrentScore()}";
    }

    public void UpdateHighScore()
    {
        HighScoreText.text = $"Best Score : {MainManager.Instance.GetCurrentHighScore()}";
    }
    public void UpdateHighScore(string playerName, int highScore)
    {
        HighScoreText.text = $"Best Score : {playerName} : {highScore}";
    }

    public void EndGameDisplay()
    {
        GameOverText.SetActive(true);
    }
}
