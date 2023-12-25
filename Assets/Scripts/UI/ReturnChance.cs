using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ReturnChance : MonoBehaviour
{
    [SerializeField]
    GameObject buttonNoThanks;
    private void Start()
    {
        buttonNoThanks.SetActive(false);
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);

        buttonNoThanks.SetActive(true);
    }
}
