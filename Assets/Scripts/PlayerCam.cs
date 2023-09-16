using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float _minViewDistance = 25f;
    public float mouseSensitivity = 100f;
    [SerializeField] Transform _playerBody;
    [Space]
    [SerializeField] Joystick _joystick;

    PlayerInput _playerInput;

    Vector2 mousePos;
    float _xRot = 0;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    void Start()
    {
#if !UNITY_ANDROID
        Cursor.lockState = CursorLockMode.Locked;
#endif
    }

    void Update()
    {

        mousePos = _playerInput.actions["Look"].ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;

        _xRot -= mousePos.y;
        _xRot = Mathf.Clamp(_xRot, -90f, _minViewDistance);

        transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mousePos.x);
    }

    void OnLook(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
}
