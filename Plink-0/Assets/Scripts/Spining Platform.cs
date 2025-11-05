using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    [SerializeField] private float tiltAngle = 30f; 
    [SerializeField] private float tiltSpeed = 2f; 

    private float currentTiltTime = 0f;

    void Update()
    {
    
        float tilt = Mathf.Sin(currentTiltTime) * tiltAngle;

        transform.rotation = Quaternion.Euler(0, 0, tilt);

        
        currentTiltTime += Time.deltaTime * tiltSpeed;
    }
}