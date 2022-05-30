using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rider;
    [SerializeField] private WheelJoint2D rearWheel;
    [SerializeField] private float _tiltForce = 100;
    [SerializeField] private float _motorSpeed = 1000;

    private void Update()
    {
        HandleInput();    
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            rearWheel.useMotor = true;
            rearWheel.motor = GetNewMotor(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rearWheel.useMotor = true;
            rearWheel.motor = GetNewMotor(-1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _rider.AddForce(Vector2.right * _tiltForce, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _rider.AddForce(Vector2.left * _tiltForce, ForceMode2D.Force);
        }

        if (!Input.anyKey && rearWheel.useMotor)
        {
            rearWheel.useMotor = false;
        }
    }

    private JointMotor2D GetNewMotor(int sign)
    {
        return new JointMotor2D { motorSpeed = sign * _motorSpeed, maxMotorTorque = float.PositiveInfinity };
    }
}
