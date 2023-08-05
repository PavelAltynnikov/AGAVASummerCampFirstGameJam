using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string _code;
    [SerializeField] private KeyPressedMode _mode;

    public event EventHandler<KeyPressedEventArgs> KeyPressed;

    private void OnMouseDown()
    {
        KeyPressed?.Invoke(this, new KeyPressedEventArgs(_code, _mode));
    }
}
