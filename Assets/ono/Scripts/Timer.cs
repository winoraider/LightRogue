using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField]  Image Image1;

    float duration = 60.0f;

    [SerializeField] TextMeshProUGUI numText;

    void Start()
    {
        Image1 = GetComponent<Image>();
        StartCoroutine(TimerStart());
    }

    void Update()
    {
        TimerStart();
    }

    IEnumerator TimerStart()
    {
        float startAmount = Image1.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime / 2;
            Image1.fillAmount = Mathf.Lerp(startAmount, 1f, elapsedTime / duration);
            yield return null;
        }
        Image1.fillAmount = 1f;
    }
}
