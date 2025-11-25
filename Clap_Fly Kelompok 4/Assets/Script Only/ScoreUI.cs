using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private ObjectSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();

        if (spawner != null)
        {
            spawner.OnScoreChanged += UpdateScoreUI;
        }

        scoreText.text = "Point: 0";
    }

    void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Point: " + newScore;
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnScoreChanged -= UpdateScoreUI;
        }
    }
}
