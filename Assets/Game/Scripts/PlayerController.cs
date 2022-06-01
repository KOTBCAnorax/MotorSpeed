using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveBack();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveForward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Lean(1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Lean(-1);
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            SetLean(-1);
        }

        if (!Input.anyKey && _rearWheel.useMotor)
        {
            _rearWheel.useMotor = false;
        }
    }

    public void MoveForward()
    {
        _rearWheel.useMotor = true;
        _rearWheel.motor = GetNewMotor(-1);
    }

    public void MoveBack()
    {
        _rearWheel.useMotor = true;
        _rearWheel.motor = GetNewMotor(1);
    }

    public void Lean(int sign)
    {
        _rb.AddTorque(sign * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void SetLean(int lean)
    {
        _leanValue = lean;
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = _maxMotorTorque };
    }
}
