using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int groundContatcts = 0;

    [SerializeField] private GameObject Players = null;

    private bool isOnPlayer = false;

    public bool isGrounded
    {
        get { return groundContatcts > 0 && !isOnPlayer; } // Return false if standing on another player
    }

    public bool ImOnAPlayer { get { return isOnPlayer; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Players.name) // its in this part
        {
            isOnPlayer = true;
            Debug.Log("I am on top of a player");
        }
        else
        {
            ++groundContatcts;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Players.gameObject)
        {
            isOnPlayer = false;
        }
        else
        {
            --groundContatcts;
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}