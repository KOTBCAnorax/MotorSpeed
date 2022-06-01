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

    private int _leanValue = 0;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (_leanValue != 0)
        {
            Lean(_leanValue);
        }
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

    public void Lean(int sign)
    {
        _rb.AddTorque(sign * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void LeanBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _leanValue = 10;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled) _leanValue = 0;
    }
    public void LeanForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            _leanValue = -10;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled) _leanValue = 0;
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = _maxMotorTorque };
    }
}
