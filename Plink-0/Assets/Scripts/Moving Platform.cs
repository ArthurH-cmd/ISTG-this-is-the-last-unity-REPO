using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
    [SerializeField] private float moveRange = 5f; 

    private Vector3 startPosition; 
    private int direction = 1; 

    void Start()
    {
        
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = moveSpeed * Time.deltaTime * direction;
        transform.position += new Vector3(movement, 0, 0);

      
        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveRange)
        {
           
            direction *= -1;
        }
    }
}