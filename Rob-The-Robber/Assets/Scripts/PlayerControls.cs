using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float BrakeStrength;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInputs();
        SpeedControl();

        if (Input.GetKey(KeyCode.Space)) 
        {
           EmengancyBreaks();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInputs() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
    }

    private void MovePlayer() 
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }

    private void SpeedControl() 
    {
        Vector3 FlatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (FlatVel.magnitude > moveSpeed) 
        {
            Vector3 CappedSpeed = FlatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(CappedSpeed.x,rb.linearVelocity.y,CappedSpeed.z);
        
        }

    }

    private void EmengancyBreaks() 
    {
        Vector3 currentVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 brakingForce = -currentVelocity.normalized * BrakeStrength; 

        rb.AddForce(brakingForce, ForceMode.Force);

   
        if (currentVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }
}