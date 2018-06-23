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

    private void OnEnable()
    {
        Elevator.OnElevatorIsOnTop += OnElevatorIsOnTop;
    }

    void OnElevatorIsOnTop()
    {
        targetT = Main.e.suicideTarget;
    }

    void Update()
    {

    }

    float pushForce = 10;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.name == "Pusher")
        {
            rb.AddForce(new Vector3(0, 0, -pushForce));
        }*/

        if (other.name == "ElevatorTrigger")
        {
            Debug.Log("Entered elevator");
            targetT = null;
            //            gotoTarget = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Pusher")
        {
            rb.AddForce(new Vector3(0, 0, -pushForce));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            Die(collision.contacts[0].point);
        }
    }

    void Die(Vector3 point)
    {
        Main.e.bloodParticles.transform.position = point;
        Main.e.bloodParticles.Emit(100);
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!targetT) return;

        target = targetT.position;

        Vector3 forceV = (target - transform.position).normalized * force;
        forceV.y = 0;
        rb.AddForce(forceV);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (targetT)
            Gizmos.DrawLine(transform.position, targetT.position);
    }
}
