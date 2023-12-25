using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    #region Singleton
    public static RewardManager instance;
    private void Awake()
    {
        instance = this;

        transform.parent = null;
    }
    #endregion

    public void Return()
    {
        BallsManager.instance.BallReturn();
        GameController.instance.board.transform.position = new(0f, -2f, 0f);
        UiManager.instance.returnChance.SetActive(false);
        UiManager.instance.playButton.SetActive(true);
    }
}
