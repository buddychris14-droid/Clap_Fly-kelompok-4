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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Tambah Koin +1");
            }
        }
    }

}