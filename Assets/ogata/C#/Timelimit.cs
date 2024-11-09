using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timelimit : MonoBehaviour
{
    [SerializeField]
    private int minutes;
    public int Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }

    [SerializeField]
    private float seconds;
    public float Seconds
    {
        get { return seconds; }
        set { seconds = value; }
    }

    [SerializeField]
    private TextMeshProUGUI TimeText;　//テキストのコンポーネントを取得
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds > 0)
        {
            seconds -= 1 * Time.deltaTime;           
        }
        if (seconds <= 0 && minutes > 0)
        {
            minutes--;
            seconds = 60;
        }
        TimeText.text = minutes + ":"+ seconds.ToString("00");
    }
}
