using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    GameController controller;

    private float currentDelta;

    private float targetDelta = 0.5f;

    private float delta;

    private void Start()
    {
        controller = GameController.instance;
    }
    public void Update()
    {
        if (GameManager.instance.gameStarted == true)
        {
            if (Input.GetMouseButton(0))
            {
                targetDelta = Input.mousePosition.x / Screen.width;

                BoardMove();
            }
        }
        currentDelta = Mathf.Lerp(currentDelta, targetDelta, controller.boardMoveSpeed * Time.deltaTime);

        delta = currentDelta - targetDelta;

        //controller.board.transform.rotation = Quaternion.Euler(0f, 0f, delta * controller.rotationSpeed); 

    }
    void BoardMove()
    {
        float currentScaleBoard = controller.board.transform.localScale.x / 2f;
        float leftClamp = -7f + currentScaleBoard;
        float rightClamp = 7f - currentScaleBoard;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 pos = raycastHit.point;
            float mousePosPixels = Mathf.Clamp(pos.x, leftClamp, rightClamp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(mousePosPixels, transform.position.y, 0f), currentDelta);
        }
    }
}
