using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathAddScore : MonoBehaviour
{
    public int score = 1;
    private void OnDestroy()
    {
        LevelManager lm = FindObjectOfType<LevelManager>();
        if(lm != null)
        {
            FindObjectOfType<LevelManager>().IncreaseScore(score);
        }
    }
}
