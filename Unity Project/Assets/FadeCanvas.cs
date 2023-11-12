using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements.Experimental;

public class FadeCanvas : MonoBehaviour
{
    bool fadeBlack = false;
    const float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, fadeBlack ? 1.0f : 0.0f, Time.deltaTime * speed);
    }
    public void fadeToBlack()
    {
        fadeBlack = true;
    }

    public void resetScreen()
    {
        fadeBlack = false;
    }

}
