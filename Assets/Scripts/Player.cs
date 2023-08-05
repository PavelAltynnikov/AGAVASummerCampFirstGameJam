using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Rigidbody _rb;

    protected Vector3 _direction;

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
