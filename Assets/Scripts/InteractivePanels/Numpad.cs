using System;
using UnityEngine;

public class Numpad : MonoBehaviour
{
    [SerializeField] private string _correctCode;
    [SerializeField] private Key[] _keys;
    [SerializeField] private Display _display;

    private string _displayText = string.Empty;

    private void Awake()
    {
        if (string.IsNullOrWhiteSpace(_correctCode))
        {
            _correctCode = "0000";
        }
    }

    private void OnEnable()
    {
        DisplayTextChanged += _display.OnTextChanged;

        foreach (var key in _keys)
        {
            key.KeyPressed += OnKeyPressed;
        }
    }

    private void OnDisable()
    {
        DisplayTextChanged -= _display.OnTextChanged;

        foreach (var key in _keys)
        {
            key.KeyPressed -= OnKeyPressed;
        }
    }

    public event EventHandler<DisplayTextChangedEventArgs> DisplayTextChanged;
    public event Action CodeMatched;
    public event Action CodeNotMatched;

    private void OnKeyPressed(object sender, KeyPressedEventArgs e)
    {
        if (e.KeyPressedMode == KeyPressedMode.Enter)
        {
            if (string.Compare(_correctCode, _displayText) == 0)
            {
                CodeMatched?.Invoke();
            }
            else
            {
                CodeNotMatched?.Invoke();
            }

            _displayText = string.Empty;
            return;
        }

        if (e.KeyPressedMode == KeyPressedMode.Decrease)
        {
            if (_displayText.Length <= 0)
            {
                return;
            }
        }

        if (e.KeyPressedMode == KeyPressedMode.Increase)
        {
            if (_displayText.Length >= 12)
            {
                return;
            }
        }

        ChangeDisplayText(e.KeyCode, e.KeyPressedMode);
    }

    private void ChangeDisplayText(string code, KeyPressedMode displayChangeMode)
    {
        switch (displayChangeMode)
        {
            case KeyPressedMode.Increase:
                _displayText += code;
                break;
            case KeyPressedMode.Decrease:
                _displayText = _displayText[..^1];
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(displayChangeMode), displayChangeMode, null);
        }

        DisplayTextChanged?.Invoke(this, new DisplayTextChangedEventArgs(_displayText));
    }
}