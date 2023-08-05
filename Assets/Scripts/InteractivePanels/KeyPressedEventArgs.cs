using System;

public class KeyPressedEventArgs : EventArgs
{
    public KeyPressedEventArgs(string keyCode, KeyPressedMode mode)
    {
        KeyCode = keyCode;
        KeyPressedMode = mode;
    }

    public string KeyCode { get; }
    public KeyPressedMode KeyPressedMode { get; }
}