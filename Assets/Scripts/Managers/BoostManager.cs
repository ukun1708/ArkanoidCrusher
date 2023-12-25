using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BoostManager : MonoBehaviour
{
    #region Singleton
    public static BoostManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int chance = 25;

    public float presentRotationSpeed = 5f;

    public GameObject[] boosters;

    

    public void BoostCreatorCheck(Vector3 createPos)
    {
        int chanceValue = Random.Range(0, chance);

        if (chanceValue == 5)
        {
            PresentCreator(createPos);
        }
    }

    void PresentCreator(Vector3 createPos)
    {
        GameObject randBoost = boosters[Random.Range(0, boosters.Length)];
        GameObject currentBoost = Instantiate(randBoost, createPos, Quaternion.identity);

        currentBoost.transform.parent = null;
    }

}
