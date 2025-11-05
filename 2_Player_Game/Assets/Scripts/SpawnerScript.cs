using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
  
    [SerializeField] private GameObject Boxes = null;
    [SerializeField] private int CurrentNumOfBoxes = 1;
    [SerializeField] private int MaxNumOfBoxes = 1;
    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private int BoxLifeTime = 10;
    private GameObject currentBox = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurrentNumOfBoxes < MaxNumOfBoxes) 
        {
            GameObject newBox  = Instantiate(Boxes,transform.parent);
            newBox.transform.position = spawnPoint.transform.position;
            currentBox = newBox;
            CurrentNumOfBoxes++;

        
        }
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (currentBox != null && currentBox.transform.position.y < -10.0f) // destroys the box if it falls 
        {
            Destroy(currentBox);
            --CurrentNumOfBoxes;
        
        
        }
    }
}
