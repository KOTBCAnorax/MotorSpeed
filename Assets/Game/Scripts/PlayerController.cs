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

    private float _leanValue = 0;
    private float _leanBackValue = 5f;
    private float _leanForwardValue = -5f;

    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _leanBackValue = 10f;
            _leanForwardValue = -10f;
        }
    }

    private void FixedUpdate()
    {
        Lean(_leanValue);
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
            _leanValue = _leanBackValue;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _leanValue = 0;
        }
    }
    public void LeanForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _leanValue = _leanForwardValue;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            _leanValue = 0;
        }
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = _maxMotorTorque };
    }
}
