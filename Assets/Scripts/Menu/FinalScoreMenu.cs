using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinalScoreMenu : MonoBehaviour
{
    public LevelManager lm;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI universalScoreText;
    public float totalTimeToFinish = 3;

    private void Start()
    {
        currentScoreText.text = "" + lm.currentScore;
        totalScoreText.text = "" + lm.GetTotalScore();
        universalScoreText.text = "0";
        StartCoroutine(SumScore());
    }

    IEnumerator SumScore()
    {
        float sumQ = lm.currentScore / (totalTimeToFinish * 60);
        float currentToitalScore = lm.GetTotalScore();
        //Debug.Log(sumQ);

       for (int i = 0; i < totalTimeToFinish * 60; i++)
        {
            currentToitalScore += sumQ;
            totalScoreText.text = "" + Mathf.RoundToInt(currentToitalScore);
            yield return null;
        }

        currentToitalScore = lm.currentScore + lm.GetTotalScore();
        totalScoreText.text = "" + currentToitalScore;


    }
}
