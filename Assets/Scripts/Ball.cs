using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    Vector3 startScale;

    BallMovement ballMovement;
    private void Start()
    {
        startScale = transform.localScale;
        ballMovement = GetComponent<BallMovement>();

        foreach (var ball in BallsManager.instance.balls)
        {
            if (ball != gameObject)
            {
                BallsManager.instance.balls.Add(gameObject);
            }
            else
            {
                print("The object is in place");
            }
        }
    }
    void Bounce(Collision collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 hitPosition = collision.transform.position;
        float boardHeight = collision.collider.bounds.size.x;

        float positionX = (ballPosition.x - hitPosition.x) / boardHeight;

        float positionY;

        if (hitPosition.y > ballPosition.y)
        {
            positionY = -1f;
        }
        else
        {
            positionY = 1f;
        }

        ballMovement.MoveBall(new Vector3(positionX, positionY, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.gameStarted == true)
        {
            SoundManager.instance.PlaySound(SoundManager.AudioType.rebound, 0.25f, Random.Range(0.8f, 1.2f), false);

            if (collision.gameObject.GetComponent<Board>())
            {
                Bounce(collision);
            }
            else if (collision.gameObject.GetComponent<Floor>())
            {
                ExplodeManager.instance.Explode(gameObject, gameObject.GetComponent<MeshRenderer>().material);
                VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, transform.position);
                BallsManager.instance.balls.Remove(gameObject);
                BallsManager.instance.CheckBall();
                CameraController.instance.Shake();
            }
            else
            {
                ballMovement.NormalizeVelocity();
            }

            if (collision.gameObject.TryGetComponent(out Fragment fragment))
            {
                fragment.Hit();
            }
        }        
    }
}
