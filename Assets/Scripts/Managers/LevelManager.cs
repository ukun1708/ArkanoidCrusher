using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    Transform levels;

    public void DownloadLevel()
    {
        for (int i = 0; i < levels.childCount; i++)
        {
            levels.GetChild(i).gameObject.SetActive(false);
        }

        var levelIndex = YandexGame.savesData.level;

        if (levelIndex == levels.childCount)
        {
            int currentLevel = Random.Range(0, levels.childCount);

            levels.GetChild(currentLevel).gameObject.SetActive(true);
        }
        else
        {
            int currentLevel = levelIndex - 1;

            levels.GetChild(currentLevel).gameObject.SetActive(true);
        }
    }
}
