using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class BallsManager : MonoBehaviour
{
    #region Singleton
    public static BallsManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public float startSpeed;

    public float ballSpeed;

    public List<GameObject> balls = new();

    IEnumerator coroutine;

    public GameObject ballPrefab;

    bool returnChance;

    private void Start()
    {
        ballSpeed = startSpeed;

        coroutine = Booster();

        returnChance = true;
    }
    public void BallReturn()
    {
        var startPos = new Vector3(0f, -1f, 0f);
        GameObject ball = Instantiate(ballPrefab, startPos, Quaternion.identity);
        balls.Add(ball);
    }

    public void CloneBall()
    {
        for (int i = 0; i < 2; i++)
        {
            var startPos = new Vector3(0f, -1f, 0f);
            GameObject ball = Instantiate(ballPrefab, startPos, Quaternion.identity);
            ball.GetComponent<BallMovement>().Launch();
        }
    }
    public void CheckBall()
    {
        if (balls.Count < 1)
        {
            if (returnChance == true)
            {
                returnChance = false;
                GameManager.instance.gameStarted = false;
                UiManager.instance.returnChance.SetActive(true);

                UiManager.instance.returnChance.GetComponent<ReturnChance>().StartTimer();
            }
            else
            {
                GameManager.instance.Lose();
            }            
        }
    }
    public void RecoveryBoost()
    {
        StartCoroutine(Booster());
    }
    IEnumerator Booster()
    {
        StopCoroutine(coroutine);

        yield return new WaitForSeconds(YandexGame.savesData.speedBoostDuration);

        ballSpeed = startSpeed;
    }
}
