using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float MaxDistanceFromStart = 20.0f;
    private Vector3 startPosition;
    [SerializeField] // prefab for ball
    private GameObject ballPrefab = null;
    [SerializeField]
    private float YFromPlayer = 10;

    private void Awake()
    {
        startPosition = transform.position;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        DropBall();

        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveSpeed * Time.deltaTime;
        }



        float distanceFromStart = position.x - startPosition.x;
        if (Mathf.Abs(distanceFromStart) > MaxDistanceFromStart)
        {
            if (distanceFromStart < 0)
            {
                position.x = startPosition.x - MaxDistanceFromStart;
            }
            else
            {
                position.x = startPosition.x + MaxDistanceFromStart;
            }
        }

        transform.position = position;


    }

    private void DropBall()
    {
        Vector3 spawnPOS = transform.position;

        //spawnPOS.y = spawnPOS.y -= YFromPlayer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ballPrefab, spawnPOS, Quaternion.identity);
        }


    }

}