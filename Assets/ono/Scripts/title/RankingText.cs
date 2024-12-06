using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;

public class RankingText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI MaxEnergyText;

    public float TimerSecond()
    {
        return timer.second;
    }
    public int TimerMinute()
    {
        return timer.minute;
    }
    public int GetLevel()
    {
        return level.levelCount;
    }

    private bool OnText = false;
    public bool onText
    {
        get { return OnText; }
        set { OnText = value; }
    }

    public void Update()
    {
        
        if(!OnText)
        {
            //Debug.Log("OnText" + OnText);
            timerText.text = timer.minute.ToString("00") + ":" + timer.second.ToString("00");
            LevelText.text = level.levelCount.ToString("");
        }
    }
}
