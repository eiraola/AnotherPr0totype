using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1.0f;
    [SerializeField]
    private float _acceleration = 1.0f;
    [SerializeField]
    private float _rotationSpeed = 1.0f;
    private float _currentSpeed = 0.0f;
    private Camera _mainCamera = null;
    private Vector3 _intendedLinearMovement = Vector3.zero;
    private CharacterController _characterController = null;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        SetTargetSpeed();
        MoveCharacter(Time.deltaTime);
        RotateTowardsDirection();
    }

    private void SetTargetSpeed()
    {
        float accelerationRate = _moveSpeed / _acceleration;
        float targetSpeed = _intendedLinearMovement.magnitude > 0.0f ? _moveSpeed : 0.0f;
        _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, accelerationRate * Time.deltaTime); 
    }

    public float GetSpeed()
    {
        return (_intendedLinearMovement * _currentSpeed).magnitude/ _moveSpeed;
    }

    public void SetLinearMovement(Vector2 newInput)
    {
        _intendedLinearMovement = Vector3.ProjectOnPlane((_mainCamera.transform.right * newInput.x + _mainCamera.transform.forward * newInput.y), Vector3.up);
    }

    private void MoveCharacter(float deltaTime)
    {
        _characterController.Move(_intendedLinearMovement * _currentSpeed * deltaTime);
    }

    private void RotateTowardsDirection()
    {
        if (_intendedLinearMovement.magnitude <= 0.01f)
        {
            return;
        }

        float singleStep = _rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, _intendedLinearMovement, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

}
