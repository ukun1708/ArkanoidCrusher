using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterClone : MonoBehaviour, IBooster
{
    BallsManager ballsManager;
    private void Start()
    {
        ballsManager = BallsManager.instance;

        foreach (var ball in BallsManager.instance.balls)
        {
            Physics.IgnoreCollision(ball.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }
    }
    public void Boost()
    {
        ballsManager.CloneBall();

        VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, transform.position);

        foreach (var ball in ballsManager.balls)
        {
            VfxManager.instance.PlayVFX(VfxManager.VfxType.widghtBoost, ball.transform.position);
        }

        Destroy(gameObject);
    }
}
