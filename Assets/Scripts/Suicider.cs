using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicider : MonoBehaviour
{

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    public Transform targetT;

    Vector3 target;

    public float force = 100;

    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        target = targetT.position;

        Vector3 forceV = (target - transform.position).normalized * force;
        forceV.y = 0;
        rb.AddForce(forceV);
    }
}
