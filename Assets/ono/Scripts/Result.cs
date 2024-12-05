using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] ECardSpawn eCard;
    [SerializeField] EXPbar expBar;

    [SerializeField] GameObject ResultObj;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI MaxEnergyText;

    private float second = 0;
    private int minute = 0;

    private float currentTime = 0f;
    private float durationTime = 5f;

    private bool Opend = false;

    public bool opend
    {
        get { return Opend; }
        set { Opend = value; }
    }
    private void Update()
    {
        if (!Opend)
        {
            GameOver gameover = eCard.enemyObj.GetComponent<GameOver>();
            gameover.ResultSetManager(this);
            CountTimer();
            LevelCount();
        }else
        {
            OpenWindow();
        }
    }
    void OpenWindow()
    {
        Time.timeScale = 0f;
        ResultObj.SetActive(true);
    }

    void CountTimer()
    {
        second += Time.deltaTime;
         minute = (int)second / 60;
        if(second >= 60)
        {
            minute++;
        }
        timerText.text = minute.ToString("00") + ":" + second.ToString("00");
    }

    void LevelCount()
    {
        LevelText.text = expBar.levelCount.ToString("");
    }
}
