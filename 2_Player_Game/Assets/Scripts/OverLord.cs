using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class OverLord : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text coinText = null; // coin text

    private void Start()
    {
        UpdateCoinText(); 
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        UpdateCoinText(); 
    }

    private void UpdateCoinText()
    {
        if (score < 10)
        {
            coinText.text = $"Coins: {score} / 10";
        }
        else if (score == 1)
        {
            coinText.text = $"A door has Opened";
        }
    }

    public int GetScore()
    {
        return score; 
    }
}