using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DemoEffect : MonoBehaviour
{
    [SerializeField] private Color[] colors = null;
    [SerializeField] private Light light;
    private int currentIndex = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex++;
            light.color = colors[currentIndex %  colors.Length];    
        }
    }
}
