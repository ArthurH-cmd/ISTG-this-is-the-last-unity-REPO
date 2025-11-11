using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField]
    private Vector3 movementDirection = Vector3.right; 
    [SerializeField]
    private float movementDistance = 5.0f; 
    [SerializeField]
    private float movementSpeed = 2.0f; 
    private Vector3 startPosition;

    
    void Start()
    {
        
        startPosition = transform.position;
    }

   
    void Update()
    {
    
        float offset = Mathf.PingPong(Time.time * movementSpeed, movementDistance);
        transform.position = startPosition + movementDirection.normalized * offset;
    }
}