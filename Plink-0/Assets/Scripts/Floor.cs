using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            Debug.Log("it hit the floor");

            Destroy(collision.gameObject);

            int randomPenalty = Random.Range(1, 21); // gets a random value from 1 - 20

            GameManager.Instance.TotalGameScore -= randomPenalty;
        }
    }
}
