using UnityEngine;

public class CodeDoor : MonoBehaviour
{
    [SerializeField] private Numpad _numpad;

    private void OnEnable()
    {
        _numpad.CodeMatched += OpenDoor;
    }

    private void OnDisable()
    {
        _numpad.CodeMatched -= OpenDoor;
    }

    private void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
