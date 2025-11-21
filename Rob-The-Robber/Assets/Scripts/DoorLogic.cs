using UnityEngine;
using UnityEngine.AI;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] GameObject player = null; 
    void Start()
    {
       
    }

 
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OpenDoor() 
    {
        Destroy(this.gameObject);
    }

    private void checkIfKey() 
    { 
        if (player)
    
    }
}
