using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public Transform[] floors;
    public Transform topFloor;

    public float targetHeight;

    private void Start()
    {
        StartCoroutine(Co());
    }

    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    int targetFloor = 0;

    float secondsToWaitOnFloor = 2;

    void Update()
    {
        float currentHeight = transform.position.y;
        float targetSpeed = targetHeight - currentHeight;
        targetSpeed = Mathf.Clamp(targetSpeed, -1, 1) * Time.deltaTime;

        transform.Translate(new Vector3(0, targetSpeed, 0));
    }

    public delegate void ElevatorIsOnTop();
    public static event ElevatorIsOnTop OnElevatorIsOnTop;

    IEnumerator Co()
    {
        float dist = Mathf.Infinity;

        while (true)
        {
            yield return new WaitForSeconds(secondsToWaitOnFloor);

            targetFloor = Random.Range(0, floors.Length);
            targetHeight = floors[targetFloor].position.y;

            dist = Mathf.Abs(targetHeight - transform.position.y);

            while (dist > 0.1f)
            {
                dist = Mathf.Abs(targetHeight - transform.position.y);
                yield return null;
            }

            yield return new WaitForSeconds(secondsToWaitOnFloor);

            targetHeight = topFloor.position.y;

            dist = Mathf.Abs(targetHeight - transform.position.y);

            while (dist > 0.1f)
            {
                dist = Mathf.Abs(targetHeight - transform.position.y);
                yield return null;
            }

            Debug.Log("TOP FLOOR!");

            if (OnElevatorIsOnTop != null)
                OnElevatorIsOnTop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (topFloor)
            Gizmos.DrawWireCube(topFloor.position, Vector3.one * 0.1f);

        Gizmos.color = Color.yellow;
        foreach (var floor in floors)
        {
            Gizmos.DrawWireCube(floor.position, Vector3.one * 0.1f);
        }
    }
}
