using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int score = 0;

    [Header("Spawn Areas (gunakan BoxCollider2D)")]
    public BoxCollider2D topArea;
    public BoxCollider2D bottomArea;
    public BoxCollider2D leftArea;
    public BoxCollider2D rightArea;

    public Transform targetPoint;
    public float spawnDelay = 5f;

    // EVENT — will notify UI script whenever score changes
    public event System.Action<int> OnScoreChanged;

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
        float zRotation = 0f;

        switch (side)
        {
            case 0: // TOP
                spawnPos = GetRandomPointInArea(topArea);
                zRotation = 0f;
                break;

            case 1: // BOTTOM
                spawnPos = GetRandomPointInArea(bottomArea);
                zRotation = 180f;
                break;

            case 2: // LEFT
                spawnPos = GetRandomPointInArea(leftArea);
                zRotation = -90f;
                break;

            case 3: // RIGHT
                spawnPos = GetRandomPointInArea(rightArea);
                zRotation = 90f;
                break;
        }

        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.Euler(0, 0, zRotation));

        MovableObject mo = obj.GetComponent<MovableObject>();
        if (mo != null)
            mo.targetPosition = targetPoint.position;
    }

    Vector2 GetRandomPointInArea(BoxCollider2D area)
    {
        Vector2 size = area.size;
        Vector2 center = (Vector2)area.transform.position + area.offset;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }

    // Add point + notify UI
    public void addpoint()
    {
        score++;
        OnScoreChanged?.Invoke(score);   // 🔴 tells ScoreUI to update UI
    }
}
