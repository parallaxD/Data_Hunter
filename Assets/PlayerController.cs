using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool CanJump => Input.GetKeyDown(_jumpKey) && _characterController.isGrounded;
    private bool IsSprinting => _canSprint && Input.GetKey(_sprintKey);

    private bool CanCrouch => Input.GetKeyDown(_crouchKey) && _characterController.isGrounded;

    [Header("MovementParameters")]
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _sprintSpeed = 7f;
    [SerializeField] private float _crouchSpeed = 1.5f;

    private Vector3 _moveDirection;
    private Vector2 _currentInput;

    [Header("Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera _playerCamera;

    private float _rotationX;

    [Header("Controls")]
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _crouchKey = KeyCode.LeftControl;

    [Range(0,10)]
    [SerializeField] private float _mouseSensivityY;
    [Range(0, 10)]
    [SerializeField] private float _mouseSensivityX;

    [SerializeField] private float _yLookLimit = 90f;

    [Header("AbilityParameters")]
    [SerializeField] private bool _canJump;
    [SerializeField] private bool _canSprint;

    [Header("jumpingParameters")]
    [SerializeField] private float _jumpForce;

    [Header("CrouchParameters")]
    [SerializeField] private float _crouchHeight = 0.5f;
    [SerializeField] private float _standingHeight = 2f;
    [SerializeField] private float _timeToCrouch = 0.25f;
    [SerializeField] private Vector3 _crouchingCenter = new Vector3(0f, 0.5f, 0f);
    [SerializeField] private Vector3 _standingCenter = new Vector3(0f, 0f, 0f);
    private bool _isCrouching;



    private void Awake()
    {
        _playerCamera = GetComponentInChildren<Camera>();
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        print(IsSprinting);
        MovePlayer();
        MovePlayerCamera();
        Jump();
        Crouch();
    }

    private void HandleMovementInput()
    {
        _currentInput = new Vector2((_isCrouching ? _crouchSpeed : IsSprinting ? _sprintSpeed : _moveSpeed) * Input.GetAxis("Vertical"), _moveSpeed * Input.GetAxis("Horizontal"));

        float moveDirectionY = _moveDirection.y;

        _moveDirection = (transform.TransformDirection(Vector3.forward) * _currentInput.x) + (transform.TransformDirection(Vector3.right) * _currentInput.y);

        _moveDirection.y = moveDirectionY;
    }


    private void HandleMouseInput()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _mouseSensivityY;
        _rotationX = Mathf.Clamp(_rotationX, -_yLookLimit, _yLookLimit);
    }

    private void MovePlayerCamera()
    {
        HandleMouseInput();

        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _mouseSensivityX, 0);
    }

    private void HandleJump()
    {
        _moveDirection.y = _jumpForce;
    }
    
    private void HandleCrouch()
    {
        StartCoroutine(CrouchStand());
    }

    private IEnumerator CrouchStand()
    {
        if (_isCrouching && Physics.Raycast(_playerCamera.transform.position, Vector3.up, 1f));
        {
            yield break;
        }

        float timeElapsed = 0;
        float targetHeight = _isCrouching ? _standingHeight : _crouchHeight;
        float currentHeight = _characterController.height;
        Vector3 targetCenter = _isCrouching ? _standingCenter : _crouchingCenter;
        Vector3 currentCenter = _characterController.center;

        while (timeElapsed < _timeToCrouch)
        {
            _characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / _timeToCrouch);
            _characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / _timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _characterController.height = targetHeight;
        _characterController.center = targetCenter;

        _isCrouching = !_isCrouching;
    }

    private void Crouch()
    {
        if (CanCrouch)
        {
            HandleCrouch();
        }
    }

    private void Jump()
    {
        if (CanJump)
        {
            HandleJump();
        }
    }



    private void MovePlayer()
    {
        HandleMovementInput();
        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= _gravityMultiplier * Time.deltaTime;
        }
        _characterController.Move(_moveDirection * Time.deltaTime);
    }


}
