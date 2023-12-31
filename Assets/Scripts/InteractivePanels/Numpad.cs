﻿using System;
using UnityEngine;

public class Numpad : MonoBehaviour
{
    [SerializeField] private string _correctCode;
    [SerializeField] private Key[] _keys;
    [SerializeField] private Display _display;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

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
                Debug.Log(_correctCode);
                CodeMatched?.Invoke();
            }
            else
            {
                Debug.Log(_correctCode);
                CodeNotMatched?.Invoke();
            }

            ChangeDisplayText(string.Empty, KeyPressedMode.None);
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
        _audioSource.PlayOneShot(_clip);
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
            case KeyPressedMode.None:
                _displayText = code;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(displayChangeMode), displayChangeMode, null);
        }

        DisplayTextChanged?.Invoke(this, new DisplayTextChangedEventArgs(_displayText));
    }
}