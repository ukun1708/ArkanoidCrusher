using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Board : MonoBehaviour
{
    public Transform ballStartPos;

    IEnumerator coroutine;
    private void Start()
    {
        float duration = 5f;
        coroutine = BackWight(duration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IBooster booster))
        {
            booster.Boost();
        }
    }
    public void RecoveryBoost(float duration)
    {
        StartCoroutine(BackWight(duration));
    }
    IEnumerator BackWight(float duration)
    {
        StopCoroutine(coroutine);

        yield return new WaitForSeconds(duration);

        transform.DOScaleX(2f, .5f).SetEase(Ease.OutBack);
    }
}
