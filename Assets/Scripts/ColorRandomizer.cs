using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour {
    [SerializeField] private Gradient colorWheel;
    [SerializeField] private Gradient spriteColorWheel;

    void Start() {
        Color myColor = colorWheel.Evaluate(Random.Range(0f, 1f)),
             childSpritesColor = spriteColorWheel.Evaluate(Random.Range(0f, 1f));

        if (GetComponent<Renderer>().material != null)
            GetComponent<Renderer>().material.color = myColor;

        foreach (Renderer child in GetComponentsInChildren<Renderer>())
        {
            if (child is SpriteRenderer)
                child.material.color = childSpritesColor;
            else
                child.material.color = myColor;
        }

    }
	
}
