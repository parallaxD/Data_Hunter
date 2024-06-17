using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private KeyCode _keyToActivate;
    [SerializeField] private GameObject _playerHUD;


    private GameObject _pauseMenu;
    private Animator _animator;


    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        _animator = GetComponentInChildren<Animator>();
        _pauseMenu = transform.Find("PauseMenu").gameObject;
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyToActivate) && !_pauseMenu.activeSelf)
        {
            ActivatePauseMenu();
        }
        else if (Input.GetKeyDown(_keyToActivate) && _pauseMenu.activeSelf)
        {
            DeactivatePauseMenu();
        }
    }

    private void ActivatePauseMenu()
    {
        _animator.Play("PauseMenu");
        _playerHUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        _pauseMenu.SetActive(true);
    }

    private void DeactivatePauseMenu()
    {
        _playerHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenu.SetActive(false);
    }


    public void QuitGameButtonAction()
    {
        Application.Quit();
    }
}
