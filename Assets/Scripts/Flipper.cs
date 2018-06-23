using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }


    void Start()
    {
        rb.maxAngularVelocity = Mathf.Infinity;

    }

    public KeyCode keycode;

    //public Transform leftFlipper;
    //public Transform rightFlipper;

    //public Transform originalRotation;
    //public Transform targetRotation;

    public HingeJoint leftJoint;

    public float targetVelocity = 100;

    void Update()
    {
        if (Input.GetKey(keycode))
        {
            var motor = leftJoint.motor;
            motor.targetVelocity = -targetVelocity;
            leftJoint.motor = motor;
        }
        else
        {
            var motor = leftJoint.motor;
            motor.targetVelocity = targetVelocity;
            leftJoint.motor = motor;
        }
    }
}
