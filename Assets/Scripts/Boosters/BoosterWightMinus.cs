using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using YG;

public class BoosterWightMinus : MonoBehaviour, IBooster
{
    private void Start()
    {
        foreach (var ball in BallsManager.instance.balls)
        {
            Physics.IgnoreCollision(ball.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }
    }
    public void Boost()
    {
        Transform board = GameController.instance.board.transform;

        if (board.localScale.x > 1f)
        {
            board.DOScaleX(board.localScale.x - 1f, .5f).SetEase(Ease.OutBack);

            GameController.instance.board.RecoveryBoost(YandexGame.savesData.wightMinusDuration);
        }

        VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, transform.position);

        VfxManager.instance.PlayVFX(VfxManager.VfxType.widghtBoost, board.position);

        Destroy(gameObject);
    }

    
}
