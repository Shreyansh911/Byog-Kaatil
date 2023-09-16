using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [Space]
    [SerializeField] PlayerInput _playerInput;

    Vector2 _moveInput;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Grab"].canceled += GrabObject;
    }

    private void OnDisable()
    {
        _playerInput.actions["Grab"].canceled -= GrabObject;
    }

    Ray rayOrigin;
    RaycastHit hitInfo;

    // Update is called once per frame
    void Update()
    {
        rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(rayOrigin, out hitInfo, 5))
        {
            Debug.Log(hitInfo.transform.name);
        }

        Debug.DrawLine(rayOrigin.origin, rayOrigin.GetPoint(5), Color.red);

    }

    private void FixedUpdate()
    {
        Vector3 playerVelocity = new Vector3(_moveInput.x * _moveSpeed, 0, _moveInput.y * _moveSpeed);
        transform.position += transform.TransformDirection(playerVelocity) * Time.deltaTime;
    }

    public void GrabObject(InputAction.CallbackContext context)
    {
        Grab();
    }

    public void Grab()
    {

    }

    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
