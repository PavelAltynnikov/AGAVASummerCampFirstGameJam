using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void OnTextChanged(object sender, DisplayTextChangedEventArgs e)
    {
        _text.text = e.DisplayText;
    }
}