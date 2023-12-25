using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        Application.targetFrameRate = -1;
    }
    #endregion

    public bool gameStarted;

    public GameObject panel;

    public void Init()
    {
        gameStarted = false;
        panel.SetActive(true);

        YandexGame.FullscreenShow();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartLevel()
    {
        panel.SetActive(false);
        UiManager.instance.playButton.SetActive(false);
        gameStarted = true;

        foreach (var ball in BallsManager.instance.balls)
        {
            if (ball != null)
            {
                ball.GetComponent<BallMovement>().Launch();
            }            
        }
    }
    public void RestartLevel()
    {
        StartCoroutine(Restart(0f));
    }
    public void NextLevel()
    {
        int currentLevel = YandexGame.savesData.level;
        currentLevel++;
        YandexGame.savesData.level = currentLevel;

        DataManager.instance.MySave();

        StartCoroutine(Restart(0f));
    }
    public void Win()
    {
        UiManager.instance.winMenu.SetActive(true);
        VfxManager.instance.PlayVFX(VfxManager.VfxType.confetti, Vector3.zero);

        gameStarted = false;

        for (int i = 0; i < BallsManager.instance.balls.Count; i++)
        {
            Destroy(BallsManager.instance.balls[i]);
        }

        DataManager.instance.MySave();
    }
    public void Lose()
    {
        UiManager.instance.loseMenu.SetActive(true);
        DataManager.instance.MySave();
    }
    IEnumerator Restart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
