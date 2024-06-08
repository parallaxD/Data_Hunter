using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private MenuCamera _menuCamera;
    [SerializeField] private float _rotateAnimDuration = 1.7f;


    public void SettinsButtonAction()
    {
        _mainMenu.SetActive(false);
        _menuCamera.PlayRotateAnim();
        StartCoroutine(WaitForAnimation(_rotateAnimDuration, _settingsPanel));
    }

    public void SettinsBackButtonAction()
    {
        _settingsPanel.SetActive(false);
        _menuCamera.PlayRotateAnimReversed();
        StartCoroutine(WaitForAnimation(_rotateAnimDuration, _mainMenu));
    }

    private IEnumerator WaitForAnimation(float delay, GameObject panelToShow)
    {
        yield return new WaitForSeconds(_rotateAnimDuration);
        panelToShow.SetActive(true);
    }

}
