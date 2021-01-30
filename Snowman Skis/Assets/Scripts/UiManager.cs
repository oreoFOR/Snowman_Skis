using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI fpsCounter;
    public TextMeshProUGUI countdownTxt;

    public GameObject smashedItTxt;
    public Animator scoreAnim;
    int displayScore;
    private void Start()
    {
        int lvlNum = PlayerPrefs.GetInt("LevelNum") + 1;
        levelTxt.text = "Level " + lvlNum.ToString();
        //InvokeRepeating("UpdateFPS", 0.1f, 0.1f);
    }
    public void UiStart()
    {
        levelTxt.gameObject.SetActive(false);
        scoreTxt.gameObject.SetActive(true);
    }
    public void UpdateScore(int score, int scoreType)
    {
        StartCoroutine(ScoreUpdater(score));
        if(scoreType == 1)
        {
            smashedItTxt.SetActive(true);
            StartCoroutine(SmashedIt());
        }
    }
    private IEnumerator ScoreUpdater(int score)
    {
        while (displayScore != score)
        {
            if (displayScore < score)
            {
                displayScore++;
                scoreTxt.text = displayScore.ToString();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartFeverCountdown()
    {
        StartCoroutine(FeverCountdown());
    }
    private IEnumerator FeverCountdown()
    {
        int countdown = 3;
        countdownTxt.text = countdown.ToString();
        countdownTxt.gameObject.SetActive(true);
        WaitForSeconds second = new WaitForSeconds(1);
        yield return second;
        countdown -= 1;
        countdownTxt.text = countdown.ToString();
        yield return second;
        countdown -= 1;
        countdownTxt.text = countdown.ToString();
        yield return second;
        countdown -= 1;
        countdownTxt.text = countdown.ToString();
        yield return second;
        countdownTxt.gameObject.SetActive(false);
    }
    IEnumerator SmashedIt()
    {
        yield return new WaitForSeconds(1);
        smashedItTxt.SetActive(false);
    }
    void UpdateFPS()
    {
        float fps = 1 / Time.deltaTime;
        fpsCounter.text = fps.ToString();
    }
}
