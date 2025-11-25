using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed = 3f;
    public float yVariation = 1f;

    void Update()
    {
        // Movement
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        transform.position += new Vector3(
            0,
            Mathf.Sin(Time.time * 10f) * yVariation * Time.deltaTime,
            0
        );

        // Click test
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            wp.z = 0;                         // <<< FIX PALING PENTING !!!
            Vector2 worldPoint = wp;

            Collider2D hit = Physics2D.OverlapPoint(worldPoint);

            if (hit != null)
            {
                Debug.Log("Kena: " + hit.name);

                if (hit.gameObject == this.gameObject)
                {
                    Debug.Log("Tambah Koin +1");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Tidak kena collider apapun");
            }
        }
    }

    void LateUpdate()
    {
        GetComponent<Collider2D>().offset = Vector2.zero;
    }

}
