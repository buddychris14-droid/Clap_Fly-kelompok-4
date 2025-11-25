using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;

    [Header("Spawn Areas (gunakan BoxCollider2D)")]
    public BoxCollider2D topArea;
    public BoxCollider2D bottomArea;
    public BoxCollider2D leftArea;
    public BoxCollider2D rightArea;

    public Transform targetPoint;
    public float spawnDelay = 5f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    System.Collections.IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnFromRandomSide();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnFromRandomSide()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPos = Vector2.zero;

        switch (side)
        {
            case 0: spawnPos = GetRandomPointInArea(topArea); break;
            case 1: spawnPos = GetRandomPointInArea(bottomArea); break;
            case 2: spawnPos = GetRandomPointInArea(leftArea); break;
            case 3: spawnPos = GetRandomPointInArea(rightArea); break;
        }

        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        MovableObject mo = obj.GetComponent<MovableObject>();
        if (mo != null)
            mo.targetPosition = targetPoint.position;
    }

    // Ambil posisi random dari BoxCollider2D area
    Vector2 GetRandomPointInArea(BoxCollider2D area)
    {
        Vector2 size = area.size;
        Vector2 center = (Vector2)area.transform.position + area.offset;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }
}
