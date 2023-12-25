using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeManager : MonoBehaviour
{
    #region Singleton
    public static ExplodeManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    GameObject cube;

    GameController controller;
    public float cubeSize = 0.3f;
    public int cubesInRow = 2; //default 3

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    private void Start()
    {
        controller = GameController.instance;
        cubesPivotDistance = cubeSize * cubesInRow / 2;

        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    public void Explode(GameObject old, Material material)
    {
        old.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePieces(x, y, z, material, old);
                }
            }
        }

        Vector3 explosionPos = old.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Piece>())
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, old.transform.position, explosionRadius, explosionUpward);
                }
            }
            if (hit.TryGetComponent(out IBooster booster))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, old.transform.position, explosionRadius, explosionUpward);
                }
            }
        }

        //Destroy(old);
    }
    private void CreatePieces(int x, int y, int z, Material material, GameObject old)
    {
        GameObject piece = ObjectPool.instance.GetPooledObject();
        //GameObject piece = Instantiate(GameController.instance.cubePrefab);

        if (piece != null)
        {
            piece.transform.position = old.transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
            piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            piece.SetActive(true);
        }

        Rigidbody rbPiece = piece.GetComponent<Rigidbody>();
        rbPiece.mass = cubeSize;

        MeshRenderer meshRenderer = piece.GetComponent<MeshRenderer>();

        meshRenderer.material = material;

        piece.GetComponent<Piece>().IgnoreCollision();
    }
}
