using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensitivity;

    private void Awake()
    {
        if (_sensitivity == 0)
        {
            _sensitivity = 1;
        }

        _camera ??= GetComponent<Camera>();
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right * (mouseY * _sensitivity * -1));
    }
}
