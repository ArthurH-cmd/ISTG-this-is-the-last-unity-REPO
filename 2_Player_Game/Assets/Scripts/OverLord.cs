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
        
            coinText.text = $"Coins: {score} / 10";


        if (score <= 10) 
        {

            coinText.text = $"A door has Opened";
        
        }
    }
}