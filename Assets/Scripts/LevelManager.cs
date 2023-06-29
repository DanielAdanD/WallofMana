using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public string currentLevelID;
    public int currentScore;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScore();
    }

    public void IncreaseScore(int addedScore)
    {
        currentScore += addedScore;
        UpdateScore();
    }

    public void SaveMaxScore()
    {
        int currentTotalScore = PlayerPrefs.GetInt("GameScore", 0);
        PlayerPrefs.SetInt("GameScore", currentScore + currentTotalScore);
    }

    public int GetTotalScore()
    {
        return PlayerPrefs.GetInt("GameScore", 0);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("GameScore", 0);
    }
    public void UpdateScore()
    {
        scoreText.text = "" + currentScore;
    }


}
