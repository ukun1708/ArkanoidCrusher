using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterSpeedUp : MonoBehaviour, IBooster
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
        float currentSpeed = ballsManager.ballSpeed;

        float changeSpeed = currentSpeed * 1.25f;

        ballsManager.ballSpeed = changeSpeed;

        ballsManager.RecoveryBoost();

        VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, transform.position);

        foreach (var ball in ballsManager.balls)
        {
            VfxManager.instance.PlayVFX(VfxManager.VfxType.widghtBoost, ball.transform.position);
        }

        Destroy(gameObject);
    }

    
}
