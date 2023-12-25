using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{    
    public int health = 1;

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            ExplodeManager.instance.Explode(gameObject, gameObject.GetComponent<MeshRenderer>().material);

            CameraController.instance.Shake();
            GameController.instance.pieceCount--;

            BoostManager.instance.BoostCreatorCheck(transform.position);

            VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, transform.position);

            CheckPiece();

            Destroy(gameObject);
        }
    }

    void CheckPiece()
    {
        if (GameController.instance.pieceCount < 1)
        {
            GameManager.instance.Win();
        }
    }
}
