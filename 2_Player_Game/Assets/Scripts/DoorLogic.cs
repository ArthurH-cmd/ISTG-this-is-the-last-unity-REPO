using UnityEngine;

public class MovingDoorLogic : MonoBehaviour
{
    public bool isOpen = false;

    private OverLord overLord; // Reference to the OverLord instance
    [SerializeField] private GameObject winScreen; // Reference to the win screen UI

    private void Start()
    {
        
        overLord = FindAnyObjectByType<OverLord>();// Find the OverLord instance in the scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (overLord != null && overLord.GetScore() == 1) // Check if OverLord has all 10 coins
        {
            isOpen = true;
            OpenDoor();
        }
        else
        {
            Debug.Log("Door remains closed. Collect all coins to open.");
        }
    }

    public void OpenDoor()
    {
        if (isOpen)
        {
            Debug.Log("Opening door...");
            ShowWinScreen(); 
            Destroy(this.gameObject);
            
        }
    }

    private void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true); // Activate the win screen UI

        }
    }

   
}