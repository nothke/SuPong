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

    void Update()
    {
        float currentHeight = transform.position.y;
        float targetSpeed = targetHeight - currentHeight;
        targetSpeed = Mathf.Clamp(targetSpeed, -20, 20);

        
    }

    float secondsToWaitOnFloor = 1;

    IEnumerator Co()
    {
        yield return new WaitForSeconds(secondsToWaitOnFloor);


    }
}
