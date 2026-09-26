using UnityEngine;

using System;
using UnityEngine.InputSystem;

public class Flippers : MonoBehaviour
{
    Rigidbody2D myBody;
    HingeJoint2D myJoint;
    InputAction flipButton;

    public InputActionAsset inputActions;
    public string actionName;

    bool flipping = false;

    public float motorSpeed = 1000f;
    public float motorForce = 10000f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myJoint = GetComponent<HingeJoint2D>();
        flipButton = inputActions.FindAction(actionName);
    }

    // Update is called once per frame
    void Update()
    {
        if (flipButton.WasPressedThisFrame())
        {
            flipping = true;
        }
    }

    void FixedUpdate()
    {
            JointMotor2D motor = myJoint.motor;
            motor.maxMotorTorque = motorForce;

            if (actionName == "FlipLeft")
            {
                if (flipping)
                {
                    motor.motorSpeed = -motorSpeed;

                    if (myJoint.jointAngle <= 19f)
                    {
                        flipping = false;
                    }
                }
                else
                {
                    motor.motorSpeed = motorSpeed;
                }
            }

            if (actionName == "FlipRight")
            {
                if (flipping)
                {
                    motor.motorSpeed = -motorSpeed;

                    if (myJoint.jointAngle >= 19f)
                    {
                        flipping = false;
                    }
                }
                else
                {
                    motor.motorSpeed = motorSpeed;
                }
            }
            myJoint.motor = motor;
            myJoint.useMotor = true;
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballBody = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 contactPosition = other.GetContact(0).normal;
            ballBody.linearVelocity = -contactPosition * 100f;
        }
    }
}
