using UnityEngine;

public class BoxLogic : MonoBehaviour
{

    private GameObject gameManager;

    [SerializeField] // prefab for ball
    private GameObject ballPrefab = null;
    [SerializeField]
    private int boxValue = 10;

   
    void Start()
    {
       
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            Debug.Log("it hit");
            Destroy(collision.gameObject);

            GameManager.Instance.TotalGameScore += boxValue;

        }
    }
}

