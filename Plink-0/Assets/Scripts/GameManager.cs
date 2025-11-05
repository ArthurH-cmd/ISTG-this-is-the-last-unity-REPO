using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalGameScore = 0;

    // Singleton 
    public static GameManager Instance { get; private set; }


    public int TotalGameScore
    {
        get { return totalGameScore; }

        set
        {
            totalGameScore = value;
            Debug.Log($"Score Updated: {totalGameScore}");
        }
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}