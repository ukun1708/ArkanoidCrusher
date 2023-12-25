using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Piece : MonoBehaviour
{
    private void Start()
    {
        IgnoreCollision();

        if (YandexGame.EnvironmentData.isMobile)
        {
            GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
        }
        else if (YandexGame.EnvironmentData.isDesktop)
        {
            GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        }
    }
    private void Update()
    {
        LimiterPosZ();
    }
    void LimiterPosZ()
    {
        float limiterZ = Mathf.Clamp(transform.position.z, -0.5f, 0.5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, limiterZ);
    }
    public void IgnoreCollision()
    {
        foreach (var ball in BallsManager.instance.balls)
        {
            Physics.IgnoreCollision(ball.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }
    }
}
