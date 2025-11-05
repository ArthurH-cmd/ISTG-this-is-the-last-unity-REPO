using UnityEngine;

public class MovingDoorLogic : MonoBehaviour
{


    public bool isOpen = false;
    public bool IsClosing = false;

  
    private Vector2 Position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      

    }


    public void OpenDoor() 
    {
        if (isOpen) 
        {
            Debug.Log("opening");
            Position.y -= 4;
        
        }

        else if (IsClosing) 
        {
            Debug.Log("Closeing");

        }
    
    
    
    }
}
