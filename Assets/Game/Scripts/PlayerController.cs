using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private WheelJoint2D _rearWheel;
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _motorSpeed = 1000;
    [SerializeField] private float _maxMotorTorque = float.PositiveInfinity;

    private void Update()
    {
        HandleInput();    
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rearWheel.useMotor = true;
            _rearWheel.motor = GetNewMotor(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _rearWheel.useMotor = true;
            _rearWheel.motor = GetNewMotor(-1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddTorque(_rotationSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddTorque(-1 * _rotationSpeed * Time.fixedDeltaTime);
        }

        if (!Input.anyKey && _rearWheel.useMotor)
        {
            _rearWheel.useMotor = false;
        }
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = _maxMotorTorque };
    }
}
