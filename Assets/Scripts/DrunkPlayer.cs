using UnityEngine;

public class DrunkPlayer : Player
{
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

        float horizontalInput = 0;
        float verticalInput = 0;

        if (Input.GetKey(KeyCode.D))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            verticalInput = -1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            horizontalInput = 1;
        }

        _direction.x = horizontalInput * _speed;
        _direction.z = verticalInput * _speed;

        _rb.velocity = _direction;
    }
}