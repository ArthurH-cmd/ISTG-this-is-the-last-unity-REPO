using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text scoreText; // Reference to the Text component

    private void Update()
    {
        // Update the score text from the GameManager
        scoreText.text = $"Score: {GameManager.Instance.TotalGameScore}";
    }
}