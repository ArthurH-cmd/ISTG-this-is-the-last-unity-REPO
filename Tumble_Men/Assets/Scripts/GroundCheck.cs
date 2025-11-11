using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject Killfloor = null;

    private int GroundContacts = 0;

    public bool IsGrounded { get { return GroundContacts > 0; } }

    private void Update()
    {
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        GroundContacts++;
    }

    private void OnTriggerExit(Collider other)
    {
        GroundContacts--;
    }
}