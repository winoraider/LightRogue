using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  static class timer
{
    public static float second = 0;
    public static int minute = 0;
}
public static class level
{
    public static int levelCount = 0;
}
public class Result : MonoBehaviour
{
    [SerializeField] ECardSpawn eCard;
    [SerializeField] EXPbar expBar;
    [SerializeField] GameOver gameOver;

    [SerializeField] GameObject ResultObj;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI MaxEnergyText;

    [SerializeField] ECardSpawn eCardSpawn;

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
        timer.second += Time.deltaTime;
        timer.minute = (int)timer.second / 60;
        if (timer.second >= 60)
        {
            timer.minute++;
        }
        timerText.text = timer.minute.ToString("00") + ":" + timer.second.ToString("00");
    }

    void LevelCount()
    {
        level.levelCount = expBar.levelCount;
        LevelText.text = level.levelCount.ToString("");
    }

    void MaxEnergy()
    {
    }
}
