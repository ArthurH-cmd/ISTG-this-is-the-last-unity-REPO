using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
}