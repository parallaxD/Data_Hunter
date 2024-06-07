using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private MenuCamera _menuCamera;
    [SerializeField] private float _rotateAnimDuration = 1.7f;

    public void SettinsButtonAction()
    {
        _mainMenu.SetActive(false);
        _menuCamera.PlayRotateAnim();
        StartCoroutine(WaitForAnimation(_rotateAnimDuration, _settingsMenu));
    }

    public void SettinsBackButtonAction()
    {
        _settingsMenu.SetActive(false);
        _menuCamera.PlayRotateAnimReversed();
        StartCoroutine(WaitForAnimation(_rotateAnimDuration, _mainMenu));
    }

    private IEnumerator WaitForAnimation(float delay, GameObject panelToShow)
    {
        yield return new WaitForSeconds(_rotateAnimDuration);
        panelToShow.SetActive(true);
    }
}
