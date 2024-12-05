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

    [SerializeField] private GameObject audioSpectrumObj_upper;
    [SerializeField] private GameObject audioSpectrumObj_lower;

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
        yield return new WaitForSeconds(duration);

        currentTime = 0f;
        audioSpectrumObj_upper.transform.localScale = Vector3.zero;
        audioSpectrumObj_lower.transform.localScale = Vector3.zero;

        audioSpectrumObj_upper.SetActive(true);
        audioSpectrumObj_lower.SetActive(true);
        while (true)
        {
            currentTime += Time.deltaTime;
            Vector3 scale = Vector3.one;
            scale.y = currentTime / duration;
            audioSpectrumObj_upper.transform.localScale = scale;
            audioSpectrumObj_lower.transform.localScale = scale;
            yield return null;
            if ( currentTime > duration )
            {
                break;
            }
        }
        audioSpectrumObj_upper.transform.localScale = Vector3.one;
        audioSpectrumObj_lower.transform.localScale = Vector3.one;
    }
}
