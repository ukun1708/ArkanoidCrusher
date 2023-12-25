using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RecyclerInMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Piece>())
        {
            other.transform.DOMove(transform.position, .25f).OnComplete(() => 
            {
                MoneyManager.instance.MoneyCreator(transform.position);

                other.gameObject.SetActive(false); // setting for objeccts pool
                //Destroy(other.gameObject);
            });
        }
    }
}
