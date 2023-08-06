using UnityEngine;

public class CodeDoor : MonoBehaviour
{
    [SerializeField] private Numpad _numpad;
    [SerializeField] private GameObject _portal;
    [SerializeField] private Transform _door;

    private void OnEnable()
    {
        Debug.Log("Enable");
        _numpad.CodeMatched += OpenDoor;
    }

    private void OnDisable()
    {
        _numpad.CodeMatched -= OpenDoor;
    }

    private void OpenDoor()
    {
        Debug.Log("OpenDoor");
        //gameObject.SetActive(false);
        _portal.SetActive(true);
        _door.Rotate(new Vector3(0, 50, 0));
    }
}
