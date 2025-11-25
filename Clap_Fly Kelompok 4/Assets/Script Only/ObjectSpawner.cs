using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public Transform targetPoint;

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        MovableObject mo = obj.GetComponent<MovableObject>();
        mo.targetPosition = targetPoint.position;
    }
}
