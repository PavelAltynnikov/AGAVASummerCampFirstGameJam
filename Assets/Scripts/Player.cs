using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _sensitivity;
    [SerializeField] protected Rigidbody _rb;

    protected bool _isOnGround = false;
    protected Vector3 _direction;

    private void Awake()
    {
        if (_sensitivity == 0)
        {
            _sensitivity = 1;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TryToJump();
        }

        RotatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected void TryToJump()
    {
        Debug.Log($"Пытаемся прыгнуть: {_isOnGround}");
        if (_jumpForce <= 0)
        {
            Debug.LogError("Ошибка прыжка. Сила прыжка должна быть больше 0");
        }

        if (!_isOnGround)
        {
            return;
        }

        var velocity = new Vector3(0f, Mathf.Abs(Physics.gravity.y * _jumpForce),0f);
        _rb.velocity = velocity;
        _isOnGround = false;

        Debug.Log($"Прыгнули: {_isOnGround}");
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
        _direction.y = _rb.velocity.y;

        _rb.velocity = transform.TransformDirection(_direction);
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * _sensitivity), Space.Self);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isOnGround = true;
            Debug.Log($"Пересеклись с полом: {_isOnGround}");
        }
    }
}
