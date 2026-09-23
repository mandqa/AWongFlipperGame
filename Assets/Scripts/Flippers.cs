using UnityEngine;
using UnityEngine.InputSystem;

public class Flippers : MonoBehaviour
{
    private HingeJoint2D hinge;
    public bool rightFlipper;
    private bool moveUp = false;

    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            moveUp = true;
            timer = 0.15f;
        }

        JointMotor2D motor = hinge.motor;
        motor.maxMotorTorque = 10000;

        if (moveUp)
        {
            if (rightFlipper)
            {
                motor.motorSpeed = 1000;
            }
            else
            {
                motor.motorSpeed = -1000;
            }
            hinge.motor = motor;
            hinge.useMotor = true;

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                moveUp = false;
            }
        }
        else
        {
            if (rightFlipper)
            {
                motor.motorSpeed = -1000;
                hinge.motor = motor;
                hinge.useMotor = true;

                if (hinge.jointAngle <= -30)
                {
                    hinge.useMotor = false;
                }
            }
            else
            {
                motor.motorSpeed = 1000;
                hinge.motor = motor;
                hinge.useMotor = true;

                if (hinge.jointAngle <= -30)
                {
                    hinge.useMotor = false;
                }
            }
        }
        
    }
}
