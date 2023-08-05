using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;

    private Vector3 _direction;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_speed <= 0)
        {
            Debug.LogError("Ошибка перемещения. Скорость игрока должна быть больше 0");
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _direction.x = horizontalInput * _speed;
        _direction.z = verticalInput * _speed;

        _rb.velocity = _direction;
    }
}
