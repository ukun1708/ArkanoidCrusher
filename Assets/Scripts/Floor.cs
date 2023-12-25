using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IBooster booster))
        {
            VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
