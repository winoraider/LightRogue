using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimation : MonoBehaviour
{
    private float duration;
    private float currentTime;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 startPosition;
    private bool isStartAnimation = false;

    void Update()
    {
        if (isStartAnimation)
        {
            currentTime += Time.deltaTime;
            
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, currentTime / duration);
            if(currentTime > duration)
            {
                isStartAnimation = false;
                transform.localPosition = endPosition;
            }
        }    
    }

    public void StartAnimation(float duration)
    {
        this.duration = duration;
        isStartAnimation=true;
    }
}
