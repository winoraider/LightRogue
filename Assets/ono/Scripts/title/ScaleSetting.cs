using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSetting : MonoBehaviour
{
    private Vector3 scale;
    [SerializeField]private float elapsedTime = 0.1f;
    [SerializeField] private float speed = 0f;
    private float currentTime = 0f;
    private bool change = false;

    private void Start()
    {
        scale = transform.localScale;
    }
    void Update()
    {;
        currentTime += Time.deltaTime;
        if (currentTime >= elapsedTime)
        {
            change = !change;
            currentTime = 0f;
            if (change)
            {
                transform.localScale = Vector3.one * (1f - speed * elapsedTime);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
        if(change)
        {
            transform.localScale += Vector3.one * speed * Time.deltaTime;
        }
        else
        {
            transform.localScale -= Vector3.one * speed * Time.deltaTime;
        }
        
    }
}
