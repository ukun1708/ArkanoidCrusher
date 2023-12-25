using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region Singleton
    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject winMenu, loseMenu, improveMenu, buttonPlay, buttonImprove, returnChance, playButton;

    public TMP_Text 
        level, 
        coins, 
        speedBoostLevel, 
        wightPlusLevel, 
        wightMinusLevel, 
        speedBoostDuration, 
        wightPlusDuration, 
        wightMinusDuration, 
        speedBoostCost, 
        wightBoostPlusCost, 
        wightBoostMinusCost;

    public GameObject[] buttons;

    private void Start()
    {
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        improveMenu.SetActive(false);
        returnChance.SetActive(false);
        playButton.SetActive(true);
    }

    public void CheckPriceButton()
    {
        foreach (var button in buttons)
        {
            if (button.TryGetComponent(out IBoosterButton boosterButton))
            {
                boosterButton.CheckCost();
            }
        }
    }

    public void ImproveMenuOpen()
    {
        improveMenu.SetActive(true);
        buttonPlay.SetActive(false);
        buttonImprove.SetActive(false);
    }
    public void ImproveMenuClose()
    {
        improveMenu.SetActive(false);
        buttonPlay.SetActive(true);
        buttonImprove.SetActive(true);
    }

    public void ReturnChance()
    {
        returnChance.SetActive(true);

        
    }
}
