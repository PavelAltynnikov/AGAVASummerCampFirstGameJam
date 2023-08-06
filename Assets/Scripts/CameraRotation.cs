using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Transform _orientation;

    private float xRotation;
    private float yRotation;

    private void Awake()
    {
        if (_sensitivity == 0)
        {
            _sensitivity = 1;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
