using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoolDownTimer : MonoBehaviour
{

    [SerializeField]  Image Image1;
    [SerializeField] private GameObject parent;

    float duration = 2.0f;
    float count = 0;


    void Start()
    {
        Image1 = GetComponent<Image>();
        StartCoroutine(TimerStart());
    }

    void Update()
    {
        TimerStart();
        count += 1 * Time.deltaTime;
        if(count >= 2)
        {
            Destroy(parent);
        }
    }

    IEnumerator TimerStart()
    {
        float startAmount = Image1.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime ;
            Image1.fillAmount = Mathf.Lerp(startAmount, 1f, elapsedTime / duration);
            yield return null;
        }
        Image1.fillAmount = 1f;
    }
}
