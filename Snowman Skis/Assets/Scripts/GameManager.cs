using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] startUi;
    public SnowManMover mover;
    public GameObject nextLvl;
    public GameObject replay;
    public GameObject confetti;
    public UiManager uiManager;
    public Animator anim;
    bool gameOver;
    public void StartGame()
    {
        for (int i = 0; i < startUi.Length; i++)
        {
            startUi[i].SetActive(false);
        }
        mover.gameStarted = true;
        uiManager.UiStart();
    }
    public void GameOver(bool success)
    {
        if (!gameOver)
        {
            gameOver = true;
            mover.gameOver = true;
            if (success)
            {
                anim.enabled = true;
                confetti.SetActive(true);
                nextLvl.SetActive(true);
            }
            else
            {
                replay.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !mover.gameStarted)
        {
            StartGame();
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void NxtLvl()
    {
        int lvlNum = PlayerPrefs.GetInt("LevelNum");
        lvlNum += 1;
        PlayerPrefs.SetInt("LevelNum", lvlNum);
        SceneManager.LoadScene(0);
    }
}
