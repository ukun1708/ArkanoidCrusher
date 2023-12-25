using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    GameObject arrow;

    GameManager gameManager;

    float rotateValue;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        arrow.SetActive(true);

        gameManager = GameManager.instance;

        rb.isKinematic = true;
    }

    private void Update()
    {
        if (gameManager.gameStarted == false)
        {
            rotateValue += Time.deltaTime;

            var z = Mathf.Cos(rotateValue) * 50f;

            transform.rotation = Quaternion.Euler(Vector3.forward * z );
        }
    }

    public void Launch()
    {
        arrow.SetActive(false);

        rb.isKinematic = false;

        MoveBall(transform.up);
    }

    public void MoveBall(Vector3 direction)
    {
        direction = direction.normalized;

        float ballSpeed = BallsManager.instance.ballSpeed;

        rb.velocity = direction * ballSpeed;
    }
    public void NormalizeVelocity()
    {
        Vector3 direction = rb.velocity.normalized;

        float ballSpeed = BallsManager.instance.ballSpeed;

        rb.velocity = direction * ballSpeed;
    }
}
