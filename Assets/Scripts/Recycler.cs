using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Recycler : MonoBehaviour
{
    [SerializeField]
    float speedRotation = 5f;
    void Update()
    {
        transform.Rotate(Vector3.forward * speedRotation);
    }
}
