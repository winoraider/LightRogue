using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField]  Image Image1;

    float TimeElapse = 60.0f;
    float speed = 1.0f;

    [SerializeField] ECardSpawn eCardSpawn;
    void Start()
    {
        Image1 = GetComponent<Image>();
    }

    void Update()
    {
        if(!eCardSpawn.BOSS)
        {
            TimerStart();
        }
    }

    void TimerStart()
    {
        Image1.fillAmount += (speed / TimeElapse) * Time.deltaTime;
    }
}
