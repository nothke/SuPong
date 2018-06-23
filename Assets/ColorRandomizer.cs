using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour {
    [SerializeField] private Gradient colorWheel;
    [SerializeField] private Gradient spriteColorWheel;

    void Start() {
        if (GetComponent<Renderer>().material != null)
            GetComponent<Renderer>().material.color = colorWheel.Evaluate(Random.Range(0f,1f));
        
        Color childSpritesColor = spriteColorWheel.Evaluate(Random.Range(0f, 1f));
        foreach (SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
        {
            child.color = childSpritesColor;
        }

    }
	
}
