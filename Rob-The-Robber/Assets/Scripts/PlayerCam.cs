using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform orentation;

    float xRoatation;
    float yRoatation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRoatation += mouseX;
        xRoatation -= mouseY;

        transform.rotation = Quaternion.Euler(xRoatation, yRoatation, 0);
        orentation.rotation = Quaternion.Euler(0, yRoatation, 0);
    }
}
