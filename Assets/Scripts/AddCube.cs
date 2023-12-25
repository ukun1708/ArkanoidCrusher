using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCube : MonoBehaviour
{
    List<GameObject> cubes = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            cubes.Add(transform.GetChild(i).gameObject);
            GameController.instance.pieceCount++;
        }

        foreach (var cube in cubes)
        {
            cube.AddComponent<MeshCollider>();
            GameController.instance.SetPhysicsMaterial(cube, GameController.PhysicsMaterialType.bounds);
            cube.AddComponent<Fragment>();
        }
    }
}
