using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    #region Singleton
    public static CameraController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion    

    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    public void Shake()
    {
        transform.DOShakePosition(0.25f, 0.25f, 5).OnComplete(() =>
        {
            transform.DOMove(startPos, 0.25f);
        });
    }
}
