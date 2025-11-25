using UnityEngine;

public class FlyPoints : MonoBehaviour
{
    public int points = 1;   // how many points this fly gives

    private ObjectSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
    }

    private void OnMouseDown()
    {
        if (spawner != null)
        {
            // add points to the spawner score
            for (int i = 0; i < points; i++)
            {
                spawner.addpoint();
            }
        }

        Destroy(gameObject); // remove the fly after clicking
    }
}

