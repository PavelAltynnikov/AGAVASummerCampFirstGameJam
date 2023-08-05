using System;

public class DisplayTextChangedEventArgs : EventArgs
{
    public DisplayTextChangedEventArgs(string displayText)
    {
        DisplayText = displayText;
    }

    public string DisplayText { get; }
}