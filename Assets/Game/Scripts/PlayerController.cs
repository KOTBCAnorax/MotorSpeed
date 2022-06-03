using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private WheelJoint2D _rearWheel;
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _motorSpeed = 1000;
    [SerializeField] private float _maxMotorTorque = float.PositiveInfinity;
    [SerializeField] private float _absoluteLeanValue = 5f;
    [SerializeField] private float _handheldDeviceModifier = 2f;

    private float _currentLeanValue = 0;

    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _absoluteLeanValue *= _handheldDeviceModifier;
        }
    }

    private void FixedUpdate()
    {
        Lean(_currentLeanValue);
    }

    public void MoveBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _rearWheel.useMotor = true;
            _rearWheel.motor = GetNewMotor(1);
        }

        if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _rearWheel.useMotor = false;
        }
    }

    public void MoveForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _rearWheel.useMotor = true;
            _rearWheel.motor = GetNewMotor(-1);
        }

        if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _rearWheel.useMotor = false;
        }
    }

    public void Lean(float leanValue)
    {
        _rb.AddTorque(leanValue * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void LeanBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _currentLeanValue = _absoluteLeanValue;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _currentLeanValue = 0;
        }
    }
    public void LeanForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _currentLeanValue = -_absoluteLeanValue;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _currentLeanValue = 0;
        }
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = _maxMotorTorque };
    }
}
