using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed = 3f;
    public float yVariation = 1f; // variasi naik-turun

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Gerak ke target
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Bebas gerak Y (opsional)
        float randomY = Mathf.Sin(Time.time * 5f) * yVariation;
        transform.position = new Vector2(transform.position.x, transform.position.y + randomY * Time.deltaTime);
    }

    void OnMouseDown()
    {
        Debug.Log("Tambah Koin +1");
    }
}