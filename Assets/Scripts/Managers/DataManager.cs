using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;
using YG;

public class DataManager : MonoBehaviour
{
    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    public static DataManager instance;
    private void Awake()
    {
        instance = this;        
    }    

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetData();
        }
    }

    public void GetData()
    {
        LoadSaveCloud();
    }

    void LoadSaveCloud()
    {
        SetDataInfo();
    }

    public void MySave()
    {
        YandexGame.SaveProgress();
    }

    public void SetDataInfo()
    {
        StartCoroutine(CheckLoadData());
    }
    IEnumerator CheckLoadData()
    {
        yield return StartCoroutine(SetData());

        UiManager.instance.CheckPriceButton();
        LevelManager.instance.DownloadLevel();
    }
    IEnumerator SetData() 
    {
        YandexGame.savesData.level = SetDataInt(YandexGame.savesData.level, 1, UiManager.instance.level);
        YandexGame.savesData.coins = SetDataInt(YandexGame.savesData.coins, 0, UiManager.instance.coins);

        YandexGame.savesData.speedBoostLevel = SetDataInt(YandexGame.savesData.speedBoostLevel, 1, UiManager.instance.speedBoostLevel);
        YandexGame.savesData.wightPlusLevel = SetDataInt(YandexGame.savesData.wightPlusLevel, 1, UiManager.instance.wightPlusLevel);
        YandexGame.savesData.wightMinusLevel = SetDataInt(YandexGame.savesData.wightMinusLevel, 1, UiManager.instance.wightMinusLevel);

        YandexGame.savesData.speedBoostDuration =SetDataFloat(YandexGame.savesData.speedBoostDuration, 5f, UiManager.instance.speedBoostDuration);
        YandexGame.savesData.wightPlusDuration = SetDataFloat(YandexGame.savesData.wightPlusDuration, 5f, UiManager.instance.wightPlusDuration);
        YandexGame.savesData.wightMinusDuration = SetDataFloat(YandexGame.savesData.wightMinusDuration, 5f, UiManager.instance.wightMinusDuration);

        YandexGame.savesData.speedBoostCost = SetDataInt(YandexGame.savesData.speedBoostCost, 100, UiManager.instance.speedBoostCost);
        YandexGame.savesData.wightBoostPlusCost = SetDataInt(YandexGame.savesData.wightBoostPlusCost, 100, UiManager.instance.wightBoostPlusCost);
        YandexGame.savesData.wightBoostMinusCost = SetDataInt(YandexGame.savesData.wightBoostMinusCost, 100, UiManager.instance.wightBoostMinusCost);

        UiManager.instance.CheckPriceButton();

        GameManager.instance.Init();

        MySave();

        yield return null;
    }
    int SetDataInt(int data, int startValue, TMP_Text ui)
    {
        if (data == 0)
        {
            data = startValue;
            ui.text = data.ToString();
        }
        else
        {
            ui.text = data.ToString();
        }

        return data;
    }

    float SetDataFloat(float data, float startValue, TMP_Text ui)
    {
        if (data == 0)
        {
            data = startValue;
            ui.text = data.ToString();
        }
        else
        {
            ui.text = data.ToString();
        }

        return data;
    }
}
