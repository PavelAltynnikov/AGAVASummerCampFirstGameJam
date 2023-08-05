using UnityEngine;

public class RisingThread : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    
    private void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, Mathf.Abs(Physics.gravity.y * _jumpForce),0f);
    }
}
