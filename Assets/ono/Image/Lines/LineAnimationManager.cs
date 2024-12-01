using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimationManager : MonoBehaviour
{
    private enum LineColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Purple,
        White
    }

    [SerializeField] private List<LineAnimation> upperLines = new List<LineAnimation>();
    [SerializeField] private List<LineAnimation> lowerLines = new List<LineAnimation>();

    [SerializeField] private float duration = 0f;
    [SerializeField] private float nextAnimationTime = 0f;

    private void Start()
    {
        upperLines[0].StartAnimation(duration);
        lowerLines[0].StartAnimation(duration);
        StartCoroutine(StartAllAnimation());
    }

    private IEnumerator StartAllAnimation()
    {
        float currentTime = 0f;
        int index = 0;

        while (true)
        {
            currentTime += Time.deltaTime;
            if(currentTime > nextAnimationTime )
            {
                currentTime = 0;
                index++;
                if(index == upperLines.Count)
                {
                    break;
                }
                upperLines[index].StartAnimation(duration);
                lowerLines[index].StartAnimation(duration);
            }
            
            yield return null;
        }
    }
}
