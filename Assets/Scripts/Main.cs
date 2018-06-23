using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main e;
    void Awake() { e = this; }

    public Elevator elevator;
    public Transform suicideTarget;

}
