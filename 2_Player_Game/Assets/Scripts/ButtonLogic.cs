using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] private GameObject LinkedDoor = null;

    private MovingDoorLogic doorLogic;

    private void Start()
    {
        
        if (LinkedDoor != null)
        {
            doorLogic = LinkedDoor.GetComponent<MovingDoorLogic>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("it hit");
        doorLogic.OpenDoor();



        


    }
}
