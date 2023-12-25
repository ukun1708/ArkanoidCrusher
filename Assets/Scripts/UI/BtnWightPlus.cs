using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BtnWightPlus : MonoBehaviour, IBoosterButton
{
    public void CheckCost()
    {
        int cost = YandexGame.savesData.wightBoostPlusCost;
        int coin = YandexGame.savesData.coins;

        if (coin < cost)
        {
            GetComponent<Button>().interactable = false;
        }
        if (coin >= cost)
        {
            GetComponent<Button>().interactable = true;
        }
    }
    public void BoostButton()
    {
        DataManager data = DataManager.instance;

        float currentDuration = YandexGame.savesData.wightPlusDuration;
        float result = currentDuration += 1;

        YandexGame.savesData.wightPlusDuration = result;
        UiManager.instance.wightPlusDuration.text = result.ToString();

        int level = ChangeLevel(YandexGame.savesData.wightPlusLevel, UiManager.instance.wightPlusLevel);
        YandexGame.savesData.wightPlusLevel = level;

        int cost = ChangePrice(YandexGame.savesData.wightBoostPlusCost, UiManager.instance.wightBoostPlusCost);
        YandexGame.savesData.wightBoostPlusCost = cost;

        data.MySave();
        UiManager.instance.CheckPriceButton();
    }
    int ChangeLevel(int level, TMP_Text text)
    {
        int currentlevel = level;
        currentlevel++;
        int resultLevel = currentlevel;

        text.text = resultLevel.ToString();

        return resultLevel;
    }
    int ChangePrice(int cost, TMP_Text text)
    {
        int coin = YandexGame.savesData.coins;
        int currentCost = cost;
        coin -= currentCost;

        int resultCoin = coin;
        YandexGame.savesData.coins = resultCoin;

        UiManager.instance.coins.text = resultCoin.ToString();

        currentCost += 100;

        int resultCost = currentCost;

        text.text = resultCost.ToString();

        return resultCost;
    }
}
