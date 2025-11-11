using TMPro; // For TextMeshPro
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Transform currentSpawnPoint;

    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float rotationSpeed = 1.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    private GroundCheck groundCheck = null;
    [SerializeField]
    private Transform lookTarget = null;
    [SerializeField]
    private float lookSensitivy = 75.0f;
    [SerializeField]
    private float lookDeadZone = 0.1f;
    [SerializeField]
    private float maxLookUp = 70.0f;
    [SerializeField]
    private float minLookDown = -70.0f;
    [SerializeField]
    private bool invertY = false;
    [SerializeField]
    private Transform respawnPoint = null;

    // Timer variables
    private float elapsedTime = 0.0f;
    private bool isTimerRunning = false;

    [SerializeField]
    private TextMeshProUGUI timerText; // Reference to the UI Text element

    private Rigidbody rigidBody = null;
    private PlayerInput input = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;
    private InputAction lookAction = null;
    private float xRotation = 0.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Debug.Assert(rigidBody != null, "PlayerController: needs a rigid body");
        input = new PlayerInput();
        moveAction = input.Player.Move;
        jumpAction = input.Player.Jump;
        lookAction = input.Player.Look;

        jumpAction.performed += OnJump;
        Cursor.lockState = CursorLockMode.Locked;

        currentSpawnPoint = respawnPoint;
    }

    private void Start()
    {
        // Start the timer when the game begins
        StartTimer();
    }

    private void OnEnable()
    {
        input.Enable();
        moveAction.Enable();
        jumpAction.Enable();
        lookAction.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        moveAction.Disable();
        jumpAction.Disable();
        lookAction.Disable();
    }

    private void Update()
    {
        // Update the timer if it's running
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }

        // Move Action
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 fwd = rigidBody.transform.forward;
        Vector3 right = rigidBody.transform.right;
        fwd.y = 0.0f;
        right.y = 0.0f;
        fwd.Normalize();
        right.Normalize();

        Vector3 moveVelocity = (fwd * moveInput.y * moveSpeed) + (right * moveInput.x * moveSpeed);
        moveVelocity.y = rigidBody.linearVelocity.y;

        rigidBody.linearVelocity = moveVelocity;
        rigidBody.angularVelocity = Vector3.zero;

        // Look Action
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        Vector2 lookDelta = Vector2.zero;

        if (lookInput.sqrMagnitude > lookDeadZone * lookDeadZone)
        {
            lookDelta = lookInput * lookSensitivy * Time.deltaTime;
        }

        Quaternion rotation = Quaternion.Euler(0.0f, lookDelta.x, 0.0f);
        rotation = rigidBody.rotation * rotation;
        rigidBody.MoveRotation(rotation);

        if (invertY)
        {
            xRotation -= lookDelta.y;
        }
        else
        {
            xRotation -= lookDelta.y;
        }

        xRotation = Mathf.Clamp(xRotation, minLookDown, maxLookUp);
        lookTarget.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Respawn Logic
        if (transform.position.y < -1)
        {
            RespawnPlayer();
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded && rigidBody.linearVelocity.y < 0.1f)
        {
            Vector3 velocity = rigidBody.linearVelocity;
            velocity.y = jumpSpeed;
            rigidBody.linearVelocity = velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnPoint") // if player hits a spawn point
        {
            Debug.Log("spawn point touched");
            SetSpawnPoint(other.transform);
        }
        if (other.tag == "End")
        {
            Debug.Log("hit end");
            StopTimer();
        }
    }

    private void SetSpawnPoint(Transform newSpawnpoint)
    {
        currentSpawnPoint = newSpawnpoint;
        Debug.Log($"spawn point set {newSpawnpoint.position.x} , {newSpawnpoint.position.y} , {newSpawnpoint.position.z}"); // debug stuff
    }

    private void RespawnPlayer()
    {
        // Move the player to the respawn point
        if (respawnPoint != null)
        {
            transform.position = currentSpawnPoint.position; // sets player back to da new spawn point
        }
        else
        {
            Debug.LogWarning("Respawn point is not set!");
        }
    }

    private void StartTimer()
    {
        elapsedTime = 0.0f;
        isTimerRunning = true;
        Debug.Log("Timer started!");
    }

    private void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log($"Timer stopped Total time: {elapsedTime} seconds");
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {elapsedTime} s";
        }
    }
}