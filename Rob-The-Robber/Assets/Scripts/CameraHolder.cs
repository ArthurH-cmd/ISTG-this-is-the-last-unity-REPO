using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] Transform cameraPos;



    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
