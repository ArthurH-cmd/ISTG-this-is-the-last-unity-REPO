using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class PlayerControler : MonoBehaviour
{

    [SerializeField]
    private GameObject SpawnPoint = null;

    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float jumpSpeed = 5.0f;

    [SerializeField]
    private GroundCheck groundCheck = null;

    [SerializeField]
    private Animator animator = null;

    private float dircetion = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;

    [SerializeField]
    private bool isPlayer2 = false;


    private Rigidbody2D rigBody = null;
    private PlayerInput playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInput();

        if (isPlayer2) // player 2 controls
        {
            moveAction = playerInput.Player2.Move;
            jumpAction = playerInput.Player2.Jump;
            jumpAction.performed += OnJump;
        }
        else // player 1 controls
        {
            moveAction = playerInput.Player.Move;
            jumpAction = playerInput.Player.Jump;
            jumpAction.performed += OnJump;
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.isGrounded || groundCheck.ImOnAPlayer == true) //&& rigBody.linearVelocityY <= 0.1f
        {
            rigBody.linearVelocityY += jumpSpeed;
            isJumping = true;
        }
    }


    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        rigBody.linearVelocityX = moveInput.x * moveSpeed;

        if (Mathf.Abs(moveInput.x) > 0.1f)
        {
            dircetion = (moveInput.x > 0.0f) ? 1.0f : -1.0f;
        }

        if (!groundCheck.isGrounded && rigBody.linearVelocityY <= 0.1f) // player falling
        {

            isFalling = true;
            isJumping = false;

            if (groundCheck.ImOnAPlayer) // if the player is ontop of another player
            {
                isFalling = false;

            }

        }

        else if (groundCheck.isGrounded) // if the player is on the ground
        {
            isFalling = false;
        }

        animator.SetFloat("Direction", dircetion);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spikes")
        {
            this.transform.position = SpawnPoint.transform.position;
        }

        if (!isPlayer2) // if the player is "Player 1"
        {
            if (collision.tag == "Fire")
            {
                this.transform.position = SpawnPoint.transform.position; // dies
            }
        }

        else if (isPlayer2)
        {
            if (collision.tag == "Water")
            {
                this.transform.position = SpawnPoint.transform.position; // dies
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        
    }
    void Start()
    {

    }

}
