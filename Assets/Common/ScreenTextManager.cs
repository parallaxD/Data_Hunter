using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTextManager : MonoBehaviour
{
    [SerializeField] private Text _screenText;


    private void Start()
    {
        HideText();
    }

    public void ShowText()
    {
        if (_screenText.enabled) return;
        _screenText.enabled = true;
    }

    public void HideText()
    {
        if (!_screenText.enabled) return;
        _screenText.enabled = false;
    }

    public void ChangeText(string newText)
    {
        if (newText == _screenText.text)
        {
            return;
        }
        _screenText.text = newText;
    }
}
