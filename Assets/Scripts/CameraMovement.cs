using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float normalSpeed, fastSpeed;

    private float currentSpeed;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Move();
            Rotate();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Move()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = fastSpeed;
        else
            currentSpeed = normalSpeed;

        transform.Translate(input * currentSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        transform.Rotate(mouseInput * sensitivity * Time.deltaTime * 50);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
