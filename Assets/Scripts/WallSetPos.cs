using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSetPos : MonoBehaviour
{
    [SerializeField]
    GameObject[] walls;

    private void Start()
    {
        float camSizeX = Camera.main.orthographicSize * Camera.main.aspect;
        float camSizeY = Camera.main.orthographicSize;
        Vector3 centerCam = Camera.main.transform.position;

        float minX = centerCam.x - camSizeX;
        float maxX = centerCam.x + camSizeX;
        float minY = centerCam.y - camSizeY;
        float maxY = centerCam.y + camSizeY;

        SetPos(walls[0], new Vector3(minX, walls[0].transform.position.y, walls[0].transform.position.z));
        SetPos(walls[1], new Vector3(maxX, walls[1].transform.position.y, walls[1].transform.position.z));
        SetPos(walls[2], new Vector3(walls[2].transform.position.x, minY, walls[2].transform.position.z));
        SetPos(walls[3], new Vector3(walls[3].transform.position.x, maxY, walls[3].transform.position.z));

        SetPos(walls[4], new Vector3(minX, maxY, walls[4].transform.position.z));
        SetPos(walls[5], new Vector3(maxX, maxY, walls[5].transform.position.z));
    }
    void SetPos(GameObject wall, Vector3 pos)
    {
        wall.transform.position = pos;
    }
}
