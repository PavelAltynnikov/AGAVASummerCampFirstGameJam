using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _sensitivity;
    [SerializeField] protected float _groundDrag;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected Transform _orientation;

    protected float _horizontalInput;
    protected float _verticalInput;
    protected bool _isOnGround = false;
    protected Vector3 _direction;

    private void Awake()
    {
        if (_sensitivity == 0)
        {
            _sensitivity = 1;
        }

        if (_groundDrag == 0)
        {
            _groundDrag = 1;
        }

        _rb ??= GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TryToJump();
        }

        MyInput();

        if (_isOnGround)
        {
            _rb.drag = _groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        _direction = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _rb.AddForce(_direction.normalized * _speed, ForceMode.Force);
    }

    protected void TryToJump()
    {
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
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isOnGround = false;
        }
    }
}
