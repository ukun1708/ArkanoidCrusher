using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    PhysicMaterial[] physicsMaterials;

    public int pieceCount;

    [Header("Board Setting")]
    public Board board;
    public float boardMoveSpeed;
    public float rotationSpeed;

    public int startScaleX = 2;

    public GameObject cubePrefab;
    public void SetPhysicsMaterial(GameObject obj, PhysicsMaterialType physicsMaterial)
    {
        obj.GetComponent<Collider>().material = physicsMaterials[(int)physicsMaterial];
    }
    public enum PhysicsMaterialType
    {
        bounds,
        noBounds
    }
}
