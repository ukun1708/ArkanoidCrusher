using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using YG;

public class MoneyManager : MonoBehaviour
{
    #region Singleton
    public static MoneyManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    [SerializeField]
    GameObject money;

    [SerializeField]
    float force;

    GameController controller;

    private void Start()
    {
        controller = GameController.instance;
    }
    public void MoneyCreator(Vector3 createPos)
    {
        GameObject currentMoney = Instantiate(money, createPos, Quaternion.identity);
        currentMoney.transform.parent = null;

        controller.SetPhysicsMaterial(currentMoney, GameController.PhysicsMaterialType.noBounds);

        Rigidbody rbMoney = currentMoney.GetComponent<Rigidbody>();
        rbMoney.interpolation = RigidbodyInterpolation.Interpolate;
        rbMoney.AddForce(Vector3.right * force, ForceMode.Impulse);

        DOVirtual.DelayedCall(4f, () =>
        {
            currentMoney.transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
            {
                Destroy(currentMoney);
            });
        });

        int CountCoin = YandexGame.savesData.coins;

        CountCoin++;

        YandexGame.savesData.coins = CountCoin;     

        UiManager.instance.coins.text = CountCoin.ToString();
    }
}
