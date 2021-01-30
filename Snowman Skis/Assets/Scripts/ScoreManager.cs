using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int hitSnowman;
    public int pass;

    public int score;
    public UiManager uiManager;

    public void IncrementScore(int scoreType)
    {
        int addScore = scoreType == 1 ? 10 : 5;
        score += addScore;
        uiManager.UpdateScore(score, scoreType);
    }
}
